import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {}

const getters = {}

const actions = {
    getNewsList ({ commit, state }, pageNo, pageSize) {
        return new Promise(function (resolve, reject) {
            let _pageno = 1;
            if (pageNo) {
                _pageno = pageNo;
            }
            let _pagesize = 15;
            if (pageSize) {
                _pagesize = pageSize;
            }

            let url = api.NEWS_LIST.replace('{0}', _pageno).replace('{1}', _pagesize)
            axios.get(url, {}).then(response => {
                let data = { lise: [] };
                if (response.data.code == 0) {
                    data = response.data.data;
                }
                resolve(data)
            });
        });
    },
    getNewsDetail ({ commit, state }, artileId) {
        return new Promise(function (resolve, reject) {
            let url = api.NEWS_DETAIL.replace('{0}', artileId);
            axios.get(url, {}).then(response => {
                let data = { lise: [] };
                if (response.data.code == 0) {
                    data = response.data.data;
                }
                resolve(data)
            });
        })
    }
}

const mutations = {}



export default {
    state,
    getters,
    actions,
    mutations
}