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

const getters = {}


const actions = {
    queryProjectList ({ commit, state }, ids) {
        return new Promise(function (resolve) {
            let url = api.PROJECT_LIST + '?cids=' + ids
            axios.get(url).then(response => {
                let data = [];
                if (response.data.code==0 && response.data.data.length > 0) {
                    data = response.data.data;
                }
                resolve(data)
            });
        });
    },
    queryProjectsDetail({ commit, state},id){
        return new Promise(function (resolve) {
            let url = api.PROJECT_DETAIL+id;
            axios.get(url).then(response => {
                let data = {};
                if (response.data.code==0) {
                    data = response.data.data;
                }
                resolve(data)
            });
        });
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