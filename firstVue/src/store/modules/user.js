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
        let wx = new WX()
        let userInfo = wx.getUserInfo(code)
        commit(types.GET_WX_USER_INFO, userInfo)
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