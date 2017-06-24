<template>
    <div v-title="'美容项目分类管理'">
        <h1 class='content-title'>美容项目分类</h1>
        <div class="content-aciton-bar">
            <label>分类名称：</label>
            <input type="text" placeholder="请在此输入" />
            <label>显示顺序：</label>
            <input type="text" placeholder="请输入数字" />
            <button @click="saveProductCat">保存</button>
        </div>
        <table class="content-datagrid">
            <colgroup>
                <col style="width:35px;" />
                <col style="width:200px;" />
                <col style="width:60px;" />
                <col style="width:60px;" />
                <col style="width:auto;" />
            </colgroup>
            <thead>
                <tr>
                    <th>序号</th>
                    <th项目名称</th>
                        <th>显示顺序</th>
                        <th>操作</th>
                        <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item,i) in list">
                    <td>{i+1}</td>
                    <td>item.Name</td>
                    <td>item.DisplayOrder</td>
                    <td>
                        <a @click="editProductCat">编辑</a>
                        <a @click="deleteProductCat">删除</a>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>


<script>

import { mapGetters } from 'vuex'

export default {
    computed: mapGetters({
        cat: 'ProjectCat',
        list: 'ProjectList'
    }),
    created() {
        this.$store.dispatch('getProjectCats');
    },
    methods: {
        editProductCat: function () {
            this.$store.dispatch('editProjectCat');
        },
        deleteProductCat: function () {
            this.$store.dispatch('deleteProjectCat').then(function () {
                this.$store.dispatch('getProjectCats');
            });
        },
        saveProductCat: function () {
            this.$store.dispatch('saveProjectCat').then(function () {
                this.$store.dispatch('getProjectCats');
            });
        }

    }
}
</script>


<style>

</style>
