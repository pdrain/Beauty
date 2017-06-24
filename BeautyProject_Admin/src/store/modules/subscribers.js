import * as types from '../types'
import axios from '../../http'
import * as constant from '../constant'


const state = {
    subscribersList: []

}

const getters = {
    SubscribersList: state => state.subscribersList


}

const actions = {
    getSubscribers({ commit, state }, subscriberStatus) {
        commit(types.SUBSCRIBERS_LIST_GET, subscriberStatus);

    }

}

const mutations = {
    [types.SUBSCRIBERS_LIST_GET]: (state, subscriberStatus) => {
        state.subscribersList = [{ ID: 1 ,Name:'客户1'}, { ID: 2  ,Name:'客户2'}, { ID: 3  ,Name:'客户3'}];

    }

}


export default {
    state,
    getters,
    actions,
    mutations
}