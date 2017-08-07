<template>
    <div v-title="'美容项目分类管理'">
        <h1 class='content-title'>美容产品分类</h1>
        <div class="content-aciton-bar">
            <button @click="addProject">增加</button>
            <button @click="editProject">编辑</button>
            <button @click="deleteProject">删除</button>
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
                                        <input type="text" v-model="project.Name" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>产品分类：</td>
                                    <td>
                                        <select v-model="project.CatID">
                                            <option v-for="option in catList" :key="option.ID" :value="option.ID">
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
                                    <td>美容项目图片：</td>
                                    <td>
                                        <button @click="choosePic('displayImage')">选择图片...</button>
                                        <input type="file" name='displayImage' style="display:none" />
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
                    <th>&nbsp;</th>
                    <th>序号</th>
                    <th>项目名称</th>
                    <th>
                        <select>
                            <option v-for="(item,i) in catList" v-bind:key="item.ID" :value="item.ID">{{item.Name}}</option>
                        </select>
                    </th>
                    <th>基础价格</th>
                    <th>预付款</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item,i) in list" v-bind:key="item.ID" v-bind:class="{'selected':item.Selected}">
                    <td>
                        <input type="checkbox" v-model="item.Selected" @click="selectItem(item.ID)" />
                    </td>
                    <td>{{i+1}}</td>
                    <td>{{item.Name}}</td>
                    <td>{{(getProjectCatName(item.CatID))}}</td>
                    <td>{{item.Price}}</td>
                    <td>{{item.Imprest}}</td>
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
            windowTitle: ''
        }
    },
    computed: {
        ...mapGetters({
            project: 'Project',
            list: 'ProjectList',
            catList: 'ProjectCatList'
        })
    },
    created() {
        this.$store.dispatch('getProjectList');
        this.$store.dispatch('getProjectCats');
    },

    methods: {

        getProjectCatName: function (id) {
            let cat = this.catList.filter((item) => item.ID == id);
            if (cat.length == 1) {
                return cat[0].Name;
            } else {
                return '';
            }
        },
        addProject: function () {
            let _this = this;
            _this.windowTitle = "新增美容项目";
            this.$store.dispatch('getProject', 0).then(function () {
                _this.displayEditView = true;
            });
        },
        editProject: function () {
            let _this = this;
            _this.windowTitle = "修改美容产品";
            this.$store.dispatch('getProject', 1).then(function () {
                _this.displayEditView = true;
            }, function (errMsg) {
                alert(errMsg)
            });
        },
        deleteProject: function () {
            let _this = this;
            this.$store.dispatch('deleteProject').then(function () {

                _this.$store.dispatch('getProjectList');
            }, function (errMsg) {
                alert(errMsg)
            });
        },
        closeEditView: function () {
            this.displayEditView = false;
        },
        selectItem: function (pId) {
            this.$store.dispatch('singleProjectSelect', pId);
        },
        choosePic: function (picName) {
            $("input[name='" + picName + "']").trigger('click');
        },
        saveProject: function () {
            this.dispatch('saveProject').then(function () {
                _this.$store.dispatch('getProjectList');
            });
        }
    }
}
</script>


<style>
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

th select {
    width: 100%;
    height: 100%;
}
</style>
