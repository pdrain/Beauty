
import url from 'url'
import axios from '../http'
import querystring from 'querystring'
import * as api from '../api'
import jssdk from 'weixin-js-sdk'

const AppId = 'wx8f561aa33d77f65a';
const secret = '2cf868bb6675f052ce94b68f9848f5a1';
const AuthBase = 'https://open.weixin.qq.com/connect/oauth2/authorize?';
//const UserInfoBase = 'https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx8f561aa33d77f65a&secret=5444ba1b31666f6052e9c703f906368b&code=061h4k8Z1G7AhY0025bZ1nbh8Z1h4k8Q&grant_type=authorization_code'
const getAccesToken = 'http://www.meilituibian.cn/sns/oauth2/access_token?'
const getUserInfo = 'https://api.weixin.qq.com/cgi-bin/user/info?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN'


class WeXinAuth {
    constructor() {

    }

    //微信授权
    doAuth (_redirectUrl) {
        this.redirectUrl = _redirectUrl;
        let url = this._getAhuthurl()

        location.href = url;
    }
    //获取微信授权地址
    _getAhuthurl () {
        let queryString = this._getQueryString()
        return AuthBase + queryString
    }
    //-----------------------------------------------------------------

    //获取微信用户信息
    getUserInfo (code) {

        var _this = this;
        return new Promise(function (resolve, reject) {
            let url = api.GET_WX_INFO + '?' + _this._getWXInfoQueryString(code)
            axios.get(url).then(response => {
                let _userinfo = null;
                if (response.data.code == 0) {
                    if (!response.data.errcode) {
                        _userinfo = response.data.data;
                    }
                }
                resolve(_userinfo);
            });
        });


    }
    //授权地址参数
    _getQueryString () {
        let param = {
            appid: AppId,
            redirect_uri: this.redirectUrl,
            response_type: 'code',
            scope: 'snsapi_userinfo',
            state: 'STATE#wechat_redirect'
        }
        return querystring.stringify(param)
    }
    //获取微信用户信息查询参数
    _getWXInfoQueryString (code) {
        let param = {
            appid: AppId,
            secret: secret,
            code: code,
        }
        return querystring.stringify(param)
    }

    //-----------------------------------------------------------------

    //获取jssdk 初始化配置
    initJSSDK (access_token, targetUrl) {
        let _this = this;
        return new Promise(function (resolve, reject) {
            let _timestamp = parseInt((new Date().getTime()) / 1000)
            let _nonceStr = _this._newGuid();
            let url = api.GET_INIT_JSSDK_INFO + '?accessToken=' + access_token + '&url=' + targetUrl + '&nonceStr=' + _nonceStr + '&timestamp=' + _timestamp

            axios.get(url).then(response => {
                if (response.data.code == 0) {
                    var cig = {
                        debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                        appId: AppId + '', // 必填，公众号的唯一标识--->用户的微信公众号appid
                        timestamp: _timestamp, // 必填，生成签名的时间戳--->系统自己生成的时间戳。
                        nonceStr: _nonceStr + '', // 必填，生成签名的随机串--->系统本地生成的UUID。
                        signature: response.data.data.signature + '',// 必填，签名，见附录1
                        jsApiList: [
                            'onMenuShareTimeline',
                            'onMenuShareAppMessage'
                        ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2--->一大串CC+CV
                    }
                    console.log(targetUrl)
                    jssdk.config(cig);

                    resolve()
                }

            });
        })

    }

    //分享初始化
    initShare (option) {
        setTimeout(() => {
            var search = location.search;
            if (search) {
                var userinfo = JSON.parse(localStorage.getItem('userinfo'));
                search += "&parent=" + userinfo.WX.openid;
            }
            let sharelink = location.origin + "/?parent=" + search + "#/"
            jssdk.onMenuShareAppMessage({
                title: option.title || "画眉鸟美丽联盟",
                desc: option.desc || "每时每刻遇见美丽的自己",
                link: sharelink,
                imgUrl: "http://www.meilituibian.cn/static/img/share-icon.jpg",
                success: function (res) {
                    //分享成功回调
                }
            });
        }, 500);

    }
    //禁用分享
    hiddenShare(){
        jssdk.hideMenuItems({
            menuList: ["menuItem:share:timeline", "menuItem:copyUrl", "menuItem:share:appMessage", "menuItem:share:qq", "menuItem:share:weiboApp", "menuItem:favorite", "menuItem:share:facebook", "menuItem:share:QZone", "menuItem:editTag", "menuItem:delete", "menuItem:copyUrl", "menuItem:originPage", "menuItem:readMode", "menuItem:openWithQQBrowser", "menuItem:openWithSafari", "menuItem:share:email", "menuItem:share:brand"] // 要隐藏的菜单项，只能隐藏“传播类”和“保护类”按钮
        });
    }
    //生产GUID
    _newGuid = function () {
        var guid = "";
        for (var i = 1; i <= 32; i++) {
            var n = Math.floor(Math.random() * 16.0).toString(16);
            guid += n;
            if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                guid += "-";
        }
        return guid;
    }

    //获取Parent OpenID
    getParentOpenId(name){
        var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
        var r = window.location.search.substr(1).match(reg);
        console.log(JSON.stringify(r))
        if (r != null) {
            console.log(JSON.stringify(r[2]))
            return unescape(r[2]);
        }
        return '';
    }
}

export default new WeXinAuth()