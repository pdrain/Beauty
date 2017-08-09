<template>
    <div v-title="'美容项目分类管理'">
        <h1 class='content-title'>美容项目分类</h1>
        <div class="content-aciton-bar">
            <label>分类名称：</label>
            <input type="text" placeholder="请在此输入"  v-model="cat.Name"/>
            <label>显示顺序：</label>
            <input type="text" placeholder="请输入数字"  v-model="cat.DisplayOrder"/>
            <button @click="saveProjectCat">保存</button>
            <button @click="resetProjectCat" v-if="cat.ID>0" >取消</button>
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
                <tr v-for="(item,i) in list" v-bind:key="item.ID">
                    <td>{{i+1}}</td>
                    <td>{{item.Name}}</td>
                    <td>{{item.DisplayOrder}}</td>
                    <td>
                        <a class="button" @click="editProjectCat(item.ID)">编辑</a>
                        <a class="button" @click="deleteProductCat(item.ID)">删除</a>
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
        list: 'ProjectCatList'
    }),
    created() {
        
        this.$store.dispatch('getProjectCats');
    },
    methods: {
        editProjectCat: function (catId) {
            this.$store.dispatch('getProjectCat',catId);
            console.log(this.cat)
        },
        deleteProjectCat: function (catId) {
            this.$store.dispatch('deleteProjectCat').then(function () {
                this.$store.dispatch('getProjectCats');
            });
        },
        saveProjectCat: function () {
            this.$store.dispatch('saveProjectCat').then(function () {
                this.$store.dispatch('getProjectCats');
            });
        },
        resetProjectCat:function(){
            this.$store.dispatch('getProjectCat',0);
        }

    }
}
</script>


<style>
a.button{cursor: pointer;color: #f60;}
</style>
