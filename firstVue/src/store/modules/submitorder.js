import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {
    submitProjectDetail: null,
    userInfo: null
}

const getters = {
    SubmitProjectDetail: state => state.submitProjectDetail,
    UserInfo: state => state.userInfo

}

const actions = {
    querySubmitProjectsDetail ({ commit, state }, projectId) {
        //获取项目明细        
        return new Promise(function (resolve) {
            let url = api.PROJECT_DETAIL + projectId;
            axios.get(url).then(response => {
                
                let data = {};
                if (response.status == 200) {
                    data = response.data;
                }
                resolve(data)
            });
        });
    },
    getUserInfo ({ commit, state }, userId) {
        commit(types.GET_USER_INFO, userId);
    },
    submitOrder ({ commit, state },order) {
        return new Promise(function(resolve){
            axios.post(api.SUBMIT_ORDER, order).then(response => {
                resolve(response)
            })
        });
    }

}

const mutations = {

    [types.SUBMIT_ORDER] (state, order) {

        // let order = "BeautyItemID=" + state.submitProjectDetail.ID + "&" +
        //     "BeautyItemName=" + state.submitProjectDetail.Name + "&" +
        //     "Price=" + state.submitProjectDetail.Price + "&" +
        //     "Imprest=" + state.submitProjectDetail.Imprest + "&" +
        //     "VipID=" + 1 + "&" +
        //     "VipName=" + 'test' + "&" +
        //     "Mobile=" + state.userInfo.mobile + "&";

        // let order = {
        //     openId:'',
        //     projectId:'',
        //     userName:'',
        //     projectName:'',
        //     phone:'',
        //     address:''
        // }



        axios.post(api.SUBMIT_ORDER, order, {
            'headers': {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        }).then(response => {

        })
    },
    [types.GET_USER_INFO] (state, userId) {
        //  getUserInfo(state, userId);
        state.userInfo = {
            contactor: '1111',
            mobile: '2222',
            intrudcer: '3333'
        };
    },
    [types.QUEREY_PROJECT_DETAIL] (state, projectId) {

    }

}


const getUserInfo = (state, userId) => {

    axios.get(api.USER_INFO).then(response => {
        state.userInfo = response.data;
    });
}




export default {
    state,
    getters,
    actions,
    mutations

}