import * as types from '../types'
import axios from '../../http'
import * as constant from '../constant'


const state = {
    sales: {},
    salesList: [],
    salesApplyList: []
}

const getters = {
    Sales: state => state.sales,
    SalesList: state => state.salesList,
    SalesApplyList: state => state.salesApplyList

}

const actions = {
    getSales({ commit, state }, salesId) {
        commit(types.SALES_GET, salesId);
    },
    getSalesList({ commit, state }, salesStatus) {
        commit(types.SALES_LIST_GET, salesStatus);

    },
    getNewApplySales({ commit, state }) {
        commit(types.SALES_APPLY_LIST_GET);
    },
    confirmSalesApply({ commit, state }) {

    },
    singleSalesSelect({ commit, state }, sId) {
        let _data = state.salesList;
        $.each(_data, (i) => {

            if (pId !== _data[i].ID) {
                _data[i].Selected = false;
            }

        });
        commit(types.SALES_LIST_GET, _data);
    },
    singleApplySalesSelect({ commit, state }, sId) {
        let _data = state.salesApplyList;
        $.each(_data, (i) => {

            if (pId !== _data[i].ID) {
                _data[i].Selected = false;
            }

        });
        commit(types.SALES_APPLY_LIST_GET, _data);
    }

}

const mutations = {
    [types.SALES_GET]: (state, salesId) => {
        state.sales = { ID: 1, Name: '业务员1' };

    },
    [types.SALES_LIST_GET]: (state, salesStatus) => {
        state.salesList = [{ ID: 1, Name: '业务员1' }, { ID: 2, Name: '业务员2' }, { ID: 3, Name: '业务员3' }];

    },
    [types.SALES_APPLY_LIST_GET]: (state) => {
        state.salesApplyList = [{ ID: 1, Name: '业务员1' }, { ID: 2, Name: '业务员2' }, { ID: 3, Name: '业务员3' }];

    }

}


export default {
    state,
    getters,
    actions,
    mutations
}