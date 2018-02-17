<template>
    <div v-title="'产品分类管理'">
        <h1 class='content-title'>美容产品分类</h1>
        <div class="content-aciton-bar">
            <label>分类名称：</label>
            <input type="text" placeholder="请在此输入" />
            <label>显示顺序：</label>
            <input type="text" placeholder="请输入数字" />
            <button @click="saveProductCat">保存</button>
        </div>
        <table class="content-datagrid">
            <colgroup>
                
                <col style="width:200px;" />
                <col style="width:200px;" />
                <col style="width:60px;" />
                <col style="width:60px;" />
                <col style="width:auto;" />
            </colgroup>
            <thead>
                <tr>
                    <th>项目分类</th>
                    <th>分类名称</th>
                    <th>美容项目</th>
                    <th>操作</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in list" v-bind:key="item.ID">
                    <td>item.Name</td>
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
import { mapGetters } from "vuex";

export default {
  computed: mapGetters({
    cat: "ProductCat",
    list: "ProductCatList"
  }),
  created() {
    let _this = this;
    _this.$store.dispatch("getProductCats", "");
  },
  mounted() {
      
  },
  methods: {
    editProductCat: function() {
      this.$store.dispatch("editProductCat");
    },
    deleteProductCat: function() {
      this.$store.dispatch("deleteProductCat").then(function() {
        this.$store.dispatch("getProductCats");
      });
    },
    saveProductCat: function() {
      this.$store.dispatch("saveProductCat").then(function() {
        this.$store.dispatch("getProductCats");
      });
    }
  }
};
</script>


<style>

</style>
