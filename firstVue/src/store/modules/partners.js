import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {}

const getters = {}

const actions = {
    getPartners ({ commit, state }, param) {
        return new Promise(function (resolve, reject) {
            let url =location.origin+ "/static/data/partners.json"
            axios.get(url, param).then(response => {
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

const mutations = {}



export default {
    state,
    getters,
    actions,
    mutations
}