import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'


const state = {
    currentProductCat: 0,
    productCats: [],
    productList: [],
    productDetail: null

}
const getters = {}
const actions = {
    queryOrders ({ commit, state }, openId) {
        return new Promise(function (resolve, reject) {
            let url = api.QUERY_ORDERS + openId
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
        });
    },
  
    queryUserPerformance ({ commit, state }, openId) {
        return new Promise(function (resolve, reject) {
            let url = api.USER_PERFOMANCES + openId
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
        });
    }

}

const mutations = {}

export default {
    state,
    getters,
    actions,
    mutations

}