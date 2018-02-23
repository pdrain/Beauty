import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util, { debug } from 'util'

const state = {
    currentCat: 0,//默认项目分类
    cats: [],//项目分类
    list: [],//项目列表
    detail: null
}

const getters = {
    ProjectCurrentCat: state => state.currentCat,//获取当前分类
    ProjectCats: state => state.cats,
    ProjectList: state => state.list,
    ProjectDetail: state => state.detail
}


const actions = {
    queryProjectCats({ commit, state }) {
        return new Promise(function(resolve){
            commit(types.QUEREY_PROJECT_CATS,resolve);
           
        });
        
    },
    chooseProjectCat({ commit, state }, catId) {
        commit(types.QUEREY_PROJECT_LIST, catId);
    },
    queryProjectsDetail({ commit, state }, projectId) {
        commit(types.QUEREY_PROJECT_DETAIL, projectId);
    }
}

const mutations = {
    [types.QUEREY_PROJECT_CATS](state,resolve) {

        axios.post(api.PROJECT_CAT,{guid:''},{
            'headers':{
                'Content-Type':'application/json'
            }}).then(response => {
            if (response.data.Code == 0) {
                state.cats = response.data.Result;
                state.currentCat = state.cats[0].Guid;
                resolve(state.currentCat);
            }
            else {
                alert(response.data.Message);
            }
        });
    },
    [types.QUEREY_PROJECT_LIST](state, catId) {

        state.currentCat = catId;
        axios.post(api.PROJECT_LIST,{guid:catId},{
            'headers':{
                'Content-Type':'application/json'
            }}).then(response => {

            if (response.data.Code == 0) {
                let result = response.data.Result;
                state.list = result;
            }
            else {
                alert(response.data.Message);
            }
        })
    },
    [types.QUEREY_PROJECT_DETAIL](state, projectId) {
        //获取项目明细   
        axios.post(api.PROJECT_DETAIL,{id:projectId},{
            'headers':{
                'Content-Type':'application/json'
            }}).then(response => {
            if (response.data.Code == 0) {
                state.detail = response.data.Result;
            }
            else {
                alert(response.data.Message);
            }
        })
    }
}



export default {
    state,
    getters,
    actions,
    mutations
}