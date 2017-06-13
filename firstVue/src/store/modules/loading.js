import * as types from '../types'

const state = {
    isDisplay: false,//显示loading
    message:'正在努力加载数据......'
}

const getters = {
    loadingState: state => state.isDisplay,//获取loading当前的现实状态
    displayMessage:state=>state.message
}

const actions = {
    showLoading({ commit,state },_isDisplay) {        
        commit(types.SHOW_LOADING,  _isDisplay );
    }
}

const mutations = {
    [types.SHOW_LOADING](state, _isDisplay ) {
        state.isDisplay = _isDisplay;
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}