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
    queryProductCats ({ commit, state }) {
        return new Promise(function (resolve, reject) {
            axios.get(api.PRODUCT_CAT).then(response => {
                if (response.data.code == 0) {
                    let data = response.data.data;
                    resolve(data)
                } else {
                    if (reject && typeof (reject) == 'function') {
                        reject();
                    }
                }
            });
        })
    },
    queryProductList ({ commit, state }, catId) {
        return new Promise(function (resolve, reject) {
            
            state.currentProductCat = catId;
            let _url_product_list = api.PRODUCT_LIST.replace('{0}', catId)
            axios.get(_url_product_list).then(response => {

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
    },
    queryProductDetail ({ commit, state }, prdId) {
        return new Promise(function (resolve, reject) {
            let _url_product_detail = api.PRODUCT_DETAIL.replace('{0}', prdId)
            axios.get(_url_product_detail).then(response => {

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
    },
    saveExchangeProduct ({ commit, state }, param) {
        return new Promise(function (resolve, reject) {
            axios.post(api.EXCHANGE_PRODUCT_SAVE,param).then(response => {

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

const mutations = {
    
}

export default {
    state,
    getters,
    actions,
    mutations

}