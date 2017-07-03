<template>
    <div v-title="'业务员管理'">
        <h1 class='content-title'>业务员管理</h1>
        <div class="content-aciton-bar">
            <button @click="getNewApplySales">新申请</button>
            <button @click="getNormalSaless">初级</button>
            <button @click="getMiddleSales">中级</button>
            <button @click="getHighSales">高级</button>
            <button @click="getHighSales">所有</button>
        </div>
        <table class="content-datagrid">
            <colgroup>
                <col style='width:35px;' />
                <col style='width:200px;' />
                <col style='width:80px;' />
                <col style='width:80px;' />
                <col style='width:80px;' />
                <col style='width:120px;' />
                <col style='width:auto;' />
            </colgroup>
            <thead>
                <tr>
                    <th>序号</th>
                    <th>客户</th>
                    <th>提交日期</th>
                    <th>预约日期</th>
                    <th>预付款</th>
                    <th>操作</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for='(item,i) in list'>
                    <td>{{i+1}}</td>
                    <td>{{item.Name}}</td>
                    <td>提交日期</td>
                    <td>预约日期</td>
                    <td>预付款</td>
                    <td>
                        <a>受理</a>
                        <a>取消</a>
                        <a>拒绝</a>
                        <a>付款</a>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="7">
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
export default {
    data() {
        return {

            msg: "hello"
        }

    },
    computed: mapGetters({
        list: 'SalesList'
    }),
    mounted() {
        this.$store.dispatch('getSalesList', constant.SalesStatus.All);
    },
    methods: {
        getAllSales: function () {
            this.$store.dispatch('getSalesList', constant.SalesStatus.All);
        },
        getNewApplySales: function () {
            this.$store.dispatch('getSalesList', constant.SalesStatus.NewApply);
        },
        getNormalSaless: function () {
            this.$store.dispatch('getSalesList', constant.SalesStatus.Normal);
        },
        getMiddleSales: function () {
            this.$store.dispatch('getSalesList', constant.SalesStatus.Middle);
        },
        getHighSales: function () {
            this.$store.dispatch('getSalesList', constant.SalesStatus.High);
        },
    }
}
</script>


<style>

</style>

