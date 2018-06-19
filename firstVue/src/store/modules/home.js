import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {
    categories: []
}
const getters = {
    categories: state => state.categories
}
const actions = {

    getAllCategories ({ commit, state }) {
        return new Promise(function (resolve, reject) {
            if (state.categories.length == 0) {
                axios.get(api.PROJECT_CAT).then(response => {
                    //commit(types.QUEREY_PROJECT_CATS, response);
                    //resolve()
                    
                    if (response.data.code == 0) {
                        state.categories = response.data;
                        resolve(state.categories)
                    }
                });
            } else {
                resolve(state.categories);
            }
        });
    }
}

const mutations = {
    [types.QUEREY_PROJECT_CATS] (state, data) {
        // state.categories = data
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}