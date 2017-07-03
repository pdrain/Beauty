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


const getters = {
    CurrentProductCat: state => state.currentProductCat,
    ProductCats: state => state.productCats,
    ProductList: state => state.productList,
    ProductDetail: state => state.productDetail

}

const actions = {
    queryProductCats({ commit, state }) {
        commit(types.QUERY_PRODUCT_CATS, state);
    },
    queryProductList({ commit, state }, catId) {
        commit(types.QUERY_PRODUCT_LIST, catId)
    }

}

const mutations = {
    [types.QUERY_PRODUCT_CATS](state) {
        axios.get(api.PRODUCT_CAT).then(response => {
            if (response.data.Code == 0) {
                state.productCats = response.data.Result;
                state.currentProductCat = state.productCats[0].ID;
            }
            else {
                alert(response.data.Message);
            }
        });
    },
    [types.QUERY_PRODUCT_LIST](state, catId) {

        state.currentProductCat = catId;
        let _url_product_list = util.format(api.PRODUCT_LIST, state.currentProductCat);
        axios.get(_url_product_list).then(response => {
            if (response.data.Code == 0) {
                state.productList = response.data.Result;
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