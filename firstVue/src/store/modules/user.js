import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'
import WX from '../../config/WeXin'

const state = {
    wxInfo: {}
    // orders: {},
    // comments: {},
    // agrees: {},
    // notice: {},
    // subscribes: {},
    // points: {},


}

const getters = {
    WXInfo: state => state.wxInfo,
    // Orders: state => state.orders,
    // Comments: state => state.comments,
    // Agrees: state => state.agrees,
    // Notice: state => state.notice,
    // Subscribes: state => state.subscribes,
    // Points: state => state.points

}

const actions = {
    getWXUserInfo ({ commit, state }, code) {

        let userInfo = WX.getUserInfo(code)
        commit(types.GET_WX_USER_INFO, userInfo)
    },
    getMyClient ({ commit, state }, openId) {
        return new Promise(function (resolve, reject) {
            let url = api.USER_CLIENTS + openId
            axios.get(url).then(response => {
                if (response.status == 200) {
                    let data = response.data;
                    resolve(data)
                } else {
                    if (reject && typeof (reject) == 'function') {
                        reject();
                    }
                }
            })
        })
    }
}

const mutations = {
    [types.GET_WX_USER_INFO] (state, data) {
        state.wxInfo = data
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}