import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'


const state = {
    dictionary: [],
    childDictionary: [],
    articleDetail: {}
}

const getters = {
    parentDict: () => dictionaryHelper.getParentDict(state),
    childDictionary: state => state.childDictionary,
    articleDetail: state => state.articleDetail
}

const actions = {
    getParentDict ({ commit, state }) {
        return new Promise(function (resolve, reject) {
            axios.get(api.DICT_CATELOG).then(response => {
                commit(types.GET_DICTIONARY, response.data);
                resolve()
            });
        });

    },
    getChildDict ({ commit, state }, id) {
        if (!id) {
            let parentDict = dictionaryHelper.getParentDict(state)
            id = parentDict[0].ID
        }
        let childs = state.dictionary.filter(item => item.ID === id)
        if (childs.length == 1) {
            commit(types.GET_DICTIONARY_CHILD, childs[0].Childs);
        }
    },
    getArticleDetail ({ commit, state }, id) {
        return new Promise(function (resolve, reject) {
            let url = api.DICT_CATELOG_ARTICLE + '/' + id+'.json'
            axios.get(url).then(response => {
                commit(types.GET_DICTIONARY_ARTICLE, response.data);
                resolve()
            });
        });
    }
}

const mutations = {
    [types.GET_DICTIONARY] (state, data) {
        state.dictionary = data
    },
    [types.GET_DICTIONARY_CHILD] (state, data) {
        state.childDictionary = data
    },
    [types.GET_DICTIONARY_ARTICLE] (state, data) {
        state.articleDetail = data
    }
}


const dictionaryHelper = {
    getParentDict: (state) => {
        if (state.dictionary.length > 0) {
            return state.dictionary.filter(item => item.ParentID == 0)
        }
        return []
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}