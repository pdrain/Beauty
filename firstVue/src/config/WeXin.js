
import url from 'url'
import http from '../http'
import querystring from 'querystring'

const AppId = 'wx8f561aa33d77f65a';
const AuthBase = 'https://open.weixin.qq.com/connect/oauth2/authorize?';
const UserInfo = 'https://api.weixin.qq.com/cgi-bin/user/info?access_token=%T&openid=OPENID&lang=zh_CN'

class WeXinAuth {
    constructor(redirectUrl) {
        this.redirectUrl = redirectUrl
    }

    doAuth () {
        location.href = this._getAhuthurl()
    }

    getUserInfo (access_tokken) {
        let userInfo = {
            "subscribe": 1,
            "openid": "o6_bmjrPTlm6_2sgVt7hMZOPfL2M",
            "nickname": "Band",
            "sex": 1,
            "language": "zh_CN",
            "city": "广州",
            "province": "广东",
            "country": "中国",
            "headimgurl": "http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0",
            "subscribe_time": 1382694957,
            "unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL",
            "remark": "",
            "groupid": 0,
            "tagid_list": [128, 2]
        }
        return userInfo;
        
        let url = UserInfo.replace('%T', access_tokken)
        http.get(url).then(response => {
            // Success
        }, reject => {
            // Fail
        });
    }

    _getAhuthurl () {
        let queryString = this._getQueryString()
        return AuthBase + queryString
    }

    _getQueryString () {
        let param = {
            appid: AppId,
            redirect_uri: this.redirectUrl,
            response_type: 'code',
            scope: 'snsapi_userinfo',
            state: ''
        }
        return querystring.stringify(param)
    }
}

export default WeXinAuth