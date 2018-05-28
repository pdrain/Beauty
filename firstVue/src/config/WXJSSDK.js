import wx from 'weixin-js-sdk'
import wxUtils from 'WeXin'
export default {
    created (_url) {
        let param = {};
        wxUtils.queryJsConfig(param, (err, obj) => {
            if (err) {
                return this.$toast(err);
            }

            console.log('jsconfig ', obj);

            wx.config(obj);

            wx.ready(() => {
                console.log('wx.ready');
            });

            wx.error(function (res) {

                console.log('wx err', res);

                //可以更新签名
            });
        });
    }
}
