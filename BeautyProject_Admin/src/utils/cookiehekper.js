import { debug } from "util";

var CookieHelper = function () { };

CookieHelper.prototype.setCookie = function (option) {
    if (!option) return;

    let domain = '/';
    if (option.domain) {
        domain = option.domain
    }

    let name = option.name
    let value = escape(option.value)
    let newCookie = name + '=' + value;

    document.cookie = newCookie;

}

CookieHelper.prototype.getCookie = function (name) {
    let cookie_value="";
    if (document.cookie.length > 0) {
        let c_start = document.cookie.indexOf(name + "=")
       
        if (c_start != -1) {
            c_start = c_start + name.length + 1
            let c_end = document.cookie.indexOf(";", c_start)
            if (c_end == -1) c_end = document.cookie.length
            cookie_value =  unescape(document.cookie.substring(c_start, c_end))
        }
    }
    console.log(cookie_value)
    return cookie_value
}

export default new CookieHelper();