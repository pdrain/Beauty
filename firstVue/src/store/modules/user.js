import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'
import WX from '../../config/WeXin'

const state = {
    wxInfo: {},
    //userInfo:{}
    // orders: {},
    // comments: {},
    // agrees: {},
    // notice: {},
    // subscribes: {},
    // points: {},


}

const getters = {
    WXInfo: state => state.wxInfo,
    //UserInfo: state => state.userInfo,
    // Orders: state => state.orders,
    // Comments: state => state.comments,
    // Agrees: state => state.agrees,
    // Notice: state => state.notice,
    // Subscribes: state => state.subscribes,
    // Points: state => state.points

}

const actions = {

    getMyClient ({ commit, state }, openId) {
        return new Promise(function (resolve, reject) {
            let url = api.USER_CLIENTS + openId
            axios.get(url).then(response => {
                if (response.data.code == 0) {
                    let data = response.data.data;
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
   
}

export default {
    state,
    getters,
    actions,
    mutations
}