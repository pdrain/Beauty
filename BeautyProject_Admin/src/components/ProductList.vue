<template>
    <div v-title="'产品分类管理'">
        <h1 class='content-title'>美容产品分类</h1>
        <div class="content-aciton-bar">
            <button @click="addProduct">增加</button>
            <button @click="editProduct">编辑</button>
            <button @click="deleteProduct">删除</button>
            <transition name="slide-fade">
                <div class="product-edit-view" v-show="displayEditView">
                    <div class="mask"></div>
                    <div class="body">
                        <div class="title">窗口
                            <a class="close" @click="closeEditView">X</a>
                        </div>
                        <table>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </transition>
        </div>
        <table class="content-datagrid">
            <colgroup>
                <col style="width:35px;"/>
                <col style="width:200px;"/>
                <col style="width:200px;"/>
                <col style="width:auto;"/>
            </colgroup>
            <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item,i) in list">
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
export default {
    data() {
        return {
            displayEditView: false
        }
    },
    computed: mapGetters({
        list: 'ProductList'
    }),
    created() {
        this.$store.dispatch('getProductList');
    },
    methods: {
        addProduct: function () {
            this.displayEditView = true;
            this.$store.dispatch('getProduct', 0).then(function () {
                this.displayEditView = true;
            });
        },
        editProduct: function () {
            let product = this.getSelectedProduct();
            this.$store.dispatch('getProduct', product.ID).then(function () {
                this.displayEditView = true;
            });
        },
        deleteProduct: function () {

        },
        getSelectedProduct: function () {

        },
        closeEditView: function () {
            this.displayEditView = false;
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
