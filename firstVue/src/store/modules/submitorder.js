import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {
    submitProjectDetail: null,
    userInfo: null
}

const getters = {
    SubmitProjectDetail:state=>state.submitProjectDetail,
    UserInfo: state => state.userInfo

}

const actions = {
     querySubmitProjectsDetail({ commit, state }, projectId) {
        commit(types.QUEREY_PROJECT_DETAIL, projectId);
    },
    getUserInfo({ commit, state }, userId) {
        commit(types.GET_USER_INFO, userId);
    },
    submitOrder({commit, state}) {
        commit(types.SUBMIT_ORDER);
    }

}

const mutations = {

    [types.SUBMIT_ORDER](state) {

        let order="BeautyItemID="+state.submitProjectDetail.ID+"&"+
            "BeautyItemName="+state.submitProjectDetail.Name+"&"+
            "Price="+state.submitProjectDetail.Price+"&"+
            "Imprest="+state.submitProjectDetail.Imprest+"&"+
            "VipID="+1+"&"+
            "VipName="+'test'+"&"+
            "Mobile="+state.userInfo.mobile+"&";

       

        axios.post(api.SUBMIT_ORDER, order,{
            'headers':{
                'Content-Type':'application/x-www-form-urlencoded'
            }
        }).then(response => {

        })
    },
    [types.GET_USER_INFO](state, userId) {
      //  getUserInfo(state, userId);
      state.userInfo={
          contactor:'1111',
          mobile:'2222',
          intrudcer:'3333'
      };
    },
     [types.QUEREY_PROJECT_DETAIL](state, projectId) {
        //获取项目明细        
        //let _url_project_detail = util.format(api.PROJECT_DETAIL, projectId);
      
        axios.post(api.PROJECT_DETAIL,{id:projectId},{
            'headers':{
                'Content-Type':'application/json'
            }}).then(response => {
            
            state.submitProjectDetail = response.data;
        })
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