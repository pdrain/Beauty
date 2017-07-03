<template>
    <div v-title="'业务员申请'">
        <h1 class='content-title'>业务员管理</h1>
        <div class="content-aciton-bar">
            <button @click="confirmSalesApply">查看申请人信息</button>
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
                                    <td>姓名：</td>
                                    <td>
                                        <input type="text" v-model="sales.Name" />
                                    </td>
                                </tr>
    
                                <tr>
                                    <td>性别：</td>
                                    <td>
                                        <label>
                                            <input type="radio" name="sex" />男</label>
                                        <label>
                                            <input type="radio" name="sex" />女</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>证件照：</td>
                                    <td>
                                        <span>
                                            <img src="" />
                                            <button @click="choosePic('identityCardFront')">选择身份证正面...</button>
                                            <input type="file" name='identityCardFront' style="display:none" />
                                        </span>
                                        <span>
                                            <img src="" />
                                            <button @click="choosePic('identityCardBack')">选择身份证反面...</button>
                                            <input type="file" name='identityCardBack' style="display:none" />
                                        </span>
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
            <col style='width:35px;' />
                <col style='width:35px;' />
                <col style='width:200px;' />
                <col style='width:80px;' />
                <col style='width:80px;' />
                <col style='width:80px;' />
                <col style='width:auto;' />
            </colgroup>
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>序号</th>
                    <th>客户</th>
                    <th>提交日期</th>
                    <th>预约日期</th>
                    <th>预付款</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for='(item,i) in list'>
                    <td>
                        <input type="checkbox" v-model="item.Selected" @click="selectItem(item.ID)" />
                    </td>
                    <td>{{i+1}}</td>
                    <td>{{item.Name}}</td>
                    <td>提交日期</td>
                    <td>预约日期</td>
                    <td>预付款</td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="8">
                        <a>上一页</a>
                        <a>下一页</a>
                        <span>第1页</span>
                        <span>共10页</span>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
</template>


<script>
import * as constant from '../store/constant'
import { mapGetters } from 'vuex'
import $ from 'jquery';
export default {
    data() {
        return {
            displayEditView: false,
            windowTitle: ''
        }

    },
    computed: mapGetters({
        sales: 'Sales',
        list: 'SalesApplyList'
    }),
    mounted() {
        this.$store.dispatch('getNewApplySales');
    },
    methods: {
        confirmSalesApply: function () {
            let _this = this;
            _this.windowTitle = "业务员申请审核";
            this.$store.dispatch('getSales', 0).then(function () {
                _this.displayEditView = true;
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
        choosePic: function (picName) {
            $("input[name='" + picName + "']").trigger('click');
        },
        selectItem: function (sId) {
            this.$store.dispatch('singleApplySalesSelect', sId);
        },
    }
}
</script>


<style>

</style>

