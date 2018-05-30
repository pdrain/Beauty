
import url from 'url'
import axios from '../http'
import querystring from 'querystring'
import * as api from '../api'

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
        // let userInfo = {
        //     "subscribe": 1,
        //     "openid": "o6_bmjrPTlm6_2sgVt7hMZOPfL2M",
        //     "nickname": "Band",
        //     "sex": 1,
        //     "language": "zh_CN",
        //     "city": "广州",
        //     "province": "广东",
        //     "country": "中国",
        //     "headimgurl": "http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0",
        //     "subscribe_time": 1382694957,
        //     "unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL",
        //     "remark": "",
        //     "groupid": 0,
        //     "tagid_list": [128, 2]
        // }
        // return userInfo;
        var _this = this;
        return new Promise(function (resolve, reject) {
            let url = api.GET_WX_INFO + '?' + _this._getWXInfoQueryString(code)
            axios.get(url).then(response => {
                console.log(response);
                if (response.status == 200) {
                    if (!response.data.errcode) {
                        window.UserInfo = response.data;
                    } else {
                        window.UserInfo = null;
                    }
                }
                resolve();
            });
        });

        // axios.get(url).then(response => {
        //     debugger
        //     // Success
        // }, err => {
        //     // Fail
        //     debugger
        // });
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
    queryJsConfig (param, callback) {
        var config = {
            debug: true,
            appId: AppId,
            timestamp: '',
            nonceStr: '',
            signature: '',
            jsApiList: [
                'onMenuShareTimeline',
                'onMenuShareAppMessage'
            ]
        }

        let _timestamp = new Date().getTime();
        let _nonceStr = this._newGuid();

        if (callback && typeof (callback) == 'function') {
            callback(null, config)
        }
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


}

export default new WeXinAuth()