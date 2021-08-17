﻿/*! Blob.js v1.1.1
 *
 * native Blob interface support (polyfill)
 *
 * By Travis Clarke, https://travismclarke.com
 * By Eli Grey, http://eligrey.com
 * By Devin Samarin, https://github.com/dsamarin
 *
 * License: MIT (https://github.com/clarketm/Blob.js/blob/master/LICENSE.md)
 *
 */
(function (e, t) {
    if (typeof exports === "object" && typeof exports.nodeName !== "string") {
        module.exports = e.document ? t(e, true) : function (e) {
            if (!e.document) {
                throw new Error("blobjs requires a window with a document")
            }
            return t(e)
        }
    } else {
        t(e)
    }
}
)(window || this, function (e, t) {
    "use strict";
    var n = /^((?!chrome|android).)*safari/i.test(navigator.userAgent);
    e.URL = e.URL || e.webkitURL;
    if (e.Blob && e.URL && !n) {
        try {
            new e.Blob;
            if (typeof define === "function" && define.amd) {
                define("blobjs", [], function () {
                    return e.Blob
                })
            }
            return e.Blob
        } catch (e) { }
    }
    var i = e.BlobBuilder || e.WebKitBlobBuilder || e.MozBlobBuilder || function (e) {
        var t = function (e) {
            return Object.prototype.toString.call(e).match(/^\[object\s(.*)\]$/)[1]
        }
            , n = function e() {
                this.data = []
            }
            , i = function e(t, n, i) {
                this.data = t;
                this.size = t.length;
                this.type = n;
                this.encoding = i
            }
            , o = n.prototype
            , r = i.prototype
            , a = e.FileReaderSync
            , f = function (e) {
                this.code = this[this.name = e]
            }
            , c = ("NOT_FOUND_ERR SECURITY_ERR ABORT_ERR NOT_READABLE_ERR ENCODING_ERR " + "NO_MODIFICATION_ALLOWED_ERR INVALID_STATE_ERR SYNTAX_ERR").split(" ")
            , s = c.length
            , l = e.URL || e.webkitURL || e
            , u = l.createObjectURL
            , d = l.revokeObjectURL
            , p = l
            , b = e.btoa
            , h = e.atob
            , R = e.ArrayBuffer
            , g = e.Uint8Array
            , w = /^[\w-]+:\/*\[?[\w\.:-]+\]?(?::[0-9]+)?/;
        i.fake = r.fake = true;
        while (s--) {
            f.prototype[c[s]] = s + 1
        }
        if (!l.createObjectURL) {
            p = e.URL = function (e) {
                var t = document.createElementNS("http://www.w3.org/1999/xhtml", "a"), n;
                t.href = e;
                if (!("origin" in t)) {
                    if (t.protocol.toLowerCase() === "data:") {
                        t.origin = null
                    } else {
                        n = e.match(w);
                        t.origin = n && n[1]
                    }
                }
                return t
            }
        }
        p.createObjectURL = function (e) {
            var t = e.type, n;
            if (t === null) {
                t = "application/octet-stream"
            }
            if (e instanceof i) {
                n = "data:" + t;
                if (e.encoding === "base64") {
                    return n + ";base64," + e.data
                } else if (e.encoding === "URI") {
                    return n + "," + decodeURIComponent(e.data)
                }
                if (b) {
                    return n + ";base64," + b(e.data)
                } else {
                    return n + "," + encodeURIComponent(e.data)
                }
            } else if (u) {
                return u.call(l, e)
            }
        }
            ;
        p.revokeObjectURL = function (e) {
            if (e.substring(0, 5) !== "data:" && d) {
                d.call(l, e)
            }
        }
            ;
        o.append = function (e) {
            var n = this.data;
            if (g && (e instanceof R || e instanceof g)) {
                var o = ""
                    , r = new g(e)
                    , c = 0
                    , s = r.length;
                for (; c < s; c++) {
                    o += String.fromCharCode(r[c])
                }
                n.push(o)
            } else if (t(e) === "Blob" || t(e) === "File") {
                if (a) {
                    var l = new a;
                    n.push(l.readAsBinaryString(e))
                } else {
                    throw new f("NOT_READABLE_ERR")
                }
            } else if (e instanceof i) {
                if (e.encoding === "base64" && h) {
                    n.push(h(e.data))
                } else if (e.encoding === "URI") {
                    n.push(decodeURIComponent(e.data))
                } else if (e.encoding === "raw") {
                    n.push(e.data)
                }
            } else {
                if (typeof e !== "string") {
                    e += ""
                }
                n.push(unescape(encodeURIComponent(e)))
            }
        }
            ;
        o.getBlob = function (e) {
            if (!arguments.length) {
                e = null
            }
            return new i(this.data.join(""), e, "raw")
        }
            ;
        o.toString = function () {
            return "[object BlobBuilder]"
        }
            ;
        r.slice = function (e, t, n) {
            var o = arguments.length;
            if (o < 3) {
                n = null
            }
            return new i(this.data.slice(e, o > 1 ? t : this.data.length), n, this.encoding)
        }
            ;
        r.toString = function () {
            return "[object Blob]"
        }
            ;
        r.close = function () {
            this.size = 0;
            delete this.data
        }
            ;
        return n
    }(e);
    var o = function (e, t) {
        var n = t ? t.type || "" : "";
        var o = new i;
        if (e) {
            for (var r = 0, a = e.length; r < a; r++) {
                if (Uint8Array && e[r] instanceof Uint8Array) {
                    o.append(e[r].buffer)
                } else {
                    o.append(e[r])
                }
            }
        }
        var f = o.getBlob(n);
        if (!f.slice && f.webkitSlice) {
            f.slice = f.webkitSlice
        }
        return f
    };
    var r = Object.getPrototypeOf || function (e) {
        return e.__proto__
    }
        ;
    o.prototype = r(new e.Blob);
    if (typeof define === "function" && define.amd) {
        define("blobjs", [], function () {
            return o
        })
    }
    if (typeof t === "undefined") {
        e.Blob = o
    }
    return o
});
