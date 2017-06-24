import * as types from '../types'
import axios from '../../http'
import * as constant from '../constant'


const state = {
    salesList: []

}

const getters = {
    SalesList: state => state.salesList


}

const actions = {
    getSales({ commit, state }, salesStatus) {
        commit(types.SALES_LIST_GET, salesStatus);

    }

}

const mutations = {
    [types.SALES_LIST_GET]: (state, salesStatus) => {
        state.salesList = [{ ID: 1 ,Name:'业务员1'}, { ID: 2  ,Name:'业务员2'}, { ID: 3  ,Name:'业务员3'}];

    }

}


export default {
    state,
    getters,
    actions,
    mutations
}