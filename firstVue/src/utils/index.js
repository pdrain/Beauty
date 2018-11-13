const utils = {}
utils.getParams = (name) => {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}

utils.isNative = ()=>{
    return navigator.userAgent.indexOf('HuaMeiNiao')>=0
   
}

export default utils;