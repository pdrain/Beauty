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
            //TODO 调用service
            let data = {};
            if (pId === 0) {
                //新增产品
                data = { ID: 3, Name: 'sss', CatID: 0 };
                commit(types.GET_PRODUCT, data);
                res.call();
            }
            if (pId === 1) {
                //编辑产品

                let selectedItem = state.productList.filter((item) => item.Selected === true)
                if (selectedItem.length == 0) {
                    rej.call(this, '请选择需要编辑的产品');
                } else {
                    data = selectedItem[0];
                    commit(types.GET_PRODUCT, data);
                    res.call();
                }
            }

        });
    },
    getProductList({ commit, state }) {
        return new Promise(function (res, rej) {
            //TODO 调用service
            let data = [
                { ID: 1, Name: '111111111111111', CatID: 1 },
                { ID: 2, Name: '2222222222222', CatID: 1 },
                { ID: 3, Name: '3333333333333', CatID: 1 },
                { ID: 4, Name: '44444444444444', CatID: 1 },
            ];
            $.each(data, function (i) {
                data[i].Selected = false;
            })
            commit(types.GET_PRODUCT_LIST, data);
        });
    },
    deleteProduct({ commit, state }) {
        return new Promise(function (res, rej) {

            let selectedItem = state.productList.filter((item) => item.Selected === true)
            if (selectedItem.length == 0) {
                rej.call(this, '请选择需要删除的产品');
            } else {
                //TODO 调用service
                res.call();
            }

        });
    },
    singleProductSelect({ commit, state }, pId) {
        let _data = state.productList;
        $.each(_data, (i) => {

            if (pId !== _data[i].ID) {
                _data[i].Selected = false;
            }

        });
        commit(types.GET_PRODUCT_LIST, _data);
    },
    saveProduct({ commit, state }) {
        let validate=function(){
            if(state.Name==='' || state.Name===undefined){
                return {value:false,msg:'产品名称不能为空！'}
            }
            if(state.DisplayImg==='' || state.DisplayImg===undefined){
                return {value:false,msg:'请选择产品显示图片！'}
            }
            if(state.ShortDesc==='' || state.ShortDesc===undefined){
                return {value:false,msg:'产品简介不能为空！'}
            }
        }
        return new Promise(function (res, rej) {
           let validateResult = this.validate();
            if (!validateResult.value) {
                rej.call(this, validateResult.msg);
            } else {
                //TODO 调用service
                res.call();
            }

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

        state.productList = data;

    },
}

export default {

    state,
    getters,
    actions,
    mutations
}