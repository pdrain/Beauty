<template>
    <div v-title="'产品分类管理'">
        <h1 class='content-title'>美容产品分类</h1>
        <div class="content-aciton-bar">
            <button @click="addProduct">增加</button>
            <button @click="editProduct">编辑</button>
            <button @click="deleteProduct">删除</button>
            <transition name="slide-fade">
                <div class="dialog-edit-view" v-show="displayEditView">
                    <div class="mask"></div>
                    <div class="body">
                        <div class="title">{{windowTitle}}
                            <a class="close" @click="closeEditView">X</a>
                        </div>
                        <br/>
                        <br/>
                        <div class="filds">
                            <table>
                                <colgroup>
                                    <col style="width:80px;" />
                                    <col style="auto" />
                                </colgroup>
                                <tr>
                                    <td>产品名称：</td>
                                    <td>
                                        <input type="text" v-model="product.Name" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>产品分类：</td>
                                    <td>
                                        <select v-model="product.CatID">
                                            <option v-for="option in catList" v-bind:value="option.ID">
                                                {{ option.Name }}
                                            </option>
                                        </select>
                                    </td>
    
                                </tr>
                                <tr>
                                    <td>产品简介：</td>
                                    <td>
                                        <textarea></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td>显示图片：</td>
                                    <td>
                                        <button @click="choosePic('displayImage')">选择图片...</button>
                                        <input type="file" name='displayImage' style="display:none"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>产品描述：</td>
                                    <td>
                                        <textarea></textarea>
                                    </td>
                                </tr>
    
                            </table>
                        </div>
                        <div class="buttons">
                            <button>保存</button>
                        </div>
                    </div>
                </div>
            </transition>
        </div>
        <table class="content-datagrid">
            <colgroup>
                <col style="width:35px;" />
                <col style="width:35px;" />
                <col style="width:200px;" />
                <col style="width:200px;" />
                <col style="width:auto;" />
            </colgroup>
            <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item,i) in list" v-bind:class="{'selected':item.Selected}">
                    <td>
                        <input type="checkbox" v-model="item.Selected" @click="selectItem(item.ID)" />
                    </td>
                    <td>{{i+1}}</td>
                    <td>{{item.Name}}</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </tbody>
            <tfoot></tfoot>
        </table>
    </div>
</template>


<script>
import { mapGetters } from 'vuex'
import $ from 'jquery'

export default {
    data() {
        return {
            displayEditView: false,
            windowTitle:''
        }
    },
    computed: mapGetters({
        product: 'Product',
        list: 'ProductList',
        catList: 'ProductCatList'
    }),
    created() {
        this.$store.dispatch('getProductList');
        this.$store.dispatch('getProductCats');
    },

    methods: {
        addProduct: function () {
            let _this = this;
            _this.windowTitle="新增产品";
            this.$store.dispatch('getProduct', 0).then(function () {
                _this.displayEditView = true;
            });
        },
        editProduct: function () {
            let _this = this;
            _this.windowTitle="修改产品";
            this.$store.dispatch('getProduct', 1).then(function () {
                _this.displayEditView = true;
            }, function (errMsg) {
                alert(errMsg)
            });
        },
        deleteProduct: function () {
            let _this = this;
            this.$store.dispatch('deleteProduct').then(function () {

                _this.$store.dispatch('getProductList');
            }, function (errMsg) {
                alert(errMsg)
            });
        },
        closeEditView: function () {
            this.displayEditView = false;
        },
        selectItem:function(pId){
            this.$store.dispatch('singleProductSelect',pId);
        },
        choosePic:function(picName){
            $("input[name='"+picName+"']").trigger('click');
        },
        saveProduct:function(){
            this.dispatch('saveProduct').then(function(){
                 _this.$store.dispatch('getProductList');
            });
        }
    }
}
</script>


<style>
.product-edit-view {
    width: 100%;
    height: 100%;
    position: absolute;
    overflow: hidden;
    left: 0px;
    top: 0px;
}

.product-edit-view .mask {
    width: 100%;
    height: 100%;
    left: 0px;
    top: 0px;
    background: #f0f0f0;
    opacity: 0.5
}

.product-edit-view .body {
    width: 90%;
    height: 80%;
    margin: auto;
    background: #fff;
    border: 1px #ccc solid;
    border-radius: 5px;
    margin-top: 50px;
    position: absolute;
    top: 3%;
    left: 5%;
    box-shadow: 0px 2px 10px #ccc;
    overflow: hidden;
}

.product-edit-view .body .title {
    width: 100%;
    height: 30px;
    line-height: 30px;
    text-indent: 10px;
    font-size: 14px;
    border-bottom: 1px #ccc solid;
    background: #f0f0f0;
}

.product-edit-view .body .title .close {
    float: right;
    margin-right: 8px;
    color: #666;
    display: block;
    width: 20px;
    height: 20px;
    font-weight: bold;
    cursor: pointer;
}

.product-edit-view .body .filds {
    width: 80%;
    height: inherit;
    margin: auto;
    overflow-y: auto;
    overflow-x: hidden;
}
.product-edit-view .body .filds table{width: 100%}

.product-edit-view .body .filds tr {
    line-height: 35px;
}

.product-edit-view .body .filds td {
    vertical-align: top;
}

.product-edit-view .body .buttons {
    width: 100%;
    text-align: center;
    position: absolute;
    bottom: 10px;
    background: #fff;
}

.product-edit-view .body .filds td:first-child {
    text-align: right;
}

.product-edit-view .body .filds input,
.product-edit-view .body .filds select,
.product-edit-view .body .filds textarea {
    width: 95%;
}

.product-edit-view .body .filds textarea {
    min-height: 50px;
}

.product-edit-view .body .filds select {
    height: 30px;
    width: 96%;
}


.slide-fade-enter-active {
    transition: all .3s ease;
}

.slide-fade-leave-active {
    transition: all .3s cubic-bezier(1.0, 0.5, 0.8, 1.0);
}

.slide-fade-enter,
.slide-fade-leave-active {
    padding-top: 50px;
    opacity: 0;
}
</style>
