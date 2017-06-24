import axios from '../../http'
import * as types from '../types'
import * as api from '../../api'
import $ from 'jquery'

const state = {
    productCat: {},
    productCatList: [],
    product: {},
    productList: []
}

const getters = {
    ProductCat: state => state.productCat,
    ProductCatList: state => state.productCatList,
    Product: state => state.product,
    ProductList: state => state.productList
}

const actions = {
    getProductCats({ commit, state }) {
        return new Promise(function (res, rej) {
            axios.get(api.GET_PRODUCT_CAT_LIST).then(function (res) {

                commit(types.GET_PROJECT_CAT_LIST, res)

                res.call();
            }, function (err) {
                console.log(err);
            });
        });

    },
    editProductCat({ commit, state }, catId) {
        return new Promise(function (res, rej) {
            let url = api.GET_PRODUCT_CAT + '/' + catId;
            axios.get(url).then(function (res) {
                commit(types.GET_PRODUCT_CAT, res)

                res.call();
            }, function (err) {
                console.log(err);
            });
        });

    },
    deleteProductCat({ commit, state }, catId) {
        return new Promise(function (res, rej) {
            axios.get(api.GET_PRODUCT_CAT_LIST).then(function (res) {
                res.call();
            }, function (err) {
                console.log(err);
            });
        });

    },
    saveProductCat({ commit, state }) {
        return new Promise(function (res, rej) {
            axios.get(api.SAVE_PRODUCT_CAT).then(function (res) {
                res.call();
            }, function (err) {
                console.log(err);
            });
        });
    },
    getProduct({ commit, state }, pId) {
        return new Promise(function (res, rej) {

        });
    },
    getProductList({ commit, state }) {
        return new Promise(function (res, rej) {
            commit(types.GET_PRODUCT_LIST, []);
        });
    }

}

const mutations = {
    [types.GET_PRODUCT_CAT_LIST](state, data) {
        state.productCatList = data;

    },
    [types.GET_PRODUCT_CAT](state, data) {
        state.productCat = data;
    },
    [types.GET_PRODUCT](state, data) {
        state.product = data;

    },
    [types.GET_PRODUCT_LIST](state, data) {
        let _data = [
            { ID: 1, Name: '' },
            { ID: 2, Name: '' },
            { ID: 3, Name: '' },
            { ID: 4, Name: '' },
        ];
        data = _data;//Mock
        
        $.each(data, function (i) {
            data[i].Selected = false;
        })
        state.productList = data;

    },
}

export default {

    state,
    getters,
    actions,
    mutations
}