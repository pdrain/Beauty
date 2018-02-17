<template>
    <div class="container" v-title="'美容项目分类管理'">
      <vue-dialog  ref="dialog" ></vue-dialog>
        <h1 class='content-title'>美容项目分类</h1>
        <div class="content-aciton-bar">
           
        </div>
        <table class="content-datagrid">
            <colgroup>
                <col style="width:150px;" />
                <col style="width:150px;" />
                <col style="width:250px;" />
                <col style="width:auto;" />
            </colgroup>
            <thead>
                <tr>
                    <th>项目目录</th>
                    <th>项目分类</th>
                        <th>项目列表</th>
                        <th>项目内容</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <ul>
                            <li :class="item.Selected?'active':''"  v-for="item in list" v-bind:key="item.ID" @click="chooseProjectCat(list,item)">
                                <span class="w80">{{item.Name}}</span>
                               
                            </li>
                        </ul>
                    </td>
                    <td>
                        <ul>
                            <li v-if="catsType.length==0">暂无项目分类</li>
                                <li  v-if="catsType.length>0" :class="item.Selected?'active':''"  v-for="item in catsType" v-bind:key="item.ID"  @click="chooseProjectCatTypeList(catsType,item)">
                                    <span class="w80">{{item.Name}}</span>
                                <span class="w20">
                                     <a class="opt fa fa-pencil fa-fw"></a>
                                <a class="opt fa fa-trash-o fa-lg" @click="deleteProjectCatType"></a>
                                </span>
                                </li>
                                <li class="blcok">
                                    <input type="text" v-show="addCatType" placeholder="项目分类名称">
                                    <a class="fa fa-hand-o-up"  v-show="!addCatType" @click="eventAddCatType">&nbsp;&nbsp;添加项目分类</a>
                                    
                                    <a class="fa fa-save" v-show="addCatType" @click="saveProjectCatType">&nbsp;&nbsp;保存</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <a class="fa fa-reply"  v-show="addCatType" @click="eventCancelCatType">&nbsp;&nbsp;取消</a>
                                </li>
                        </ul>
                    </td>
                    <td>
                        <ul>
                            <li v-if="projectList.length==0">暂无项目分类</li>
                                <li  v-if="projectList.length>0" :class="item.Selected?'active':''"  v-for="item in projectList" v-bind:key="item.ID"  @click="chooseProjectCatTypeList(catsType,item)">
                                    <span class="w80">{{item.Name}}</span>
                                <span class="w20">
                                     <a class="opt fa fa-pencil fa-fw"></a>
                                <a class="opt fa fa-trash-o fa-lg" @click="deleteProject"></a>
                                </span>
                                </li>
                            <li class="blcok">
                                    
                                    <a class="fa fa-hand-o-up" v-show="!addProject" @click="eventAddProject">&nbsp;&nbsp;添加美容项目</a>
                                    <a class="fa fa-hand-o-up" v-show="addProject" style="color:#ccc;" >&nbsp;&nbsp;添加美容项目</a>
                                    
                                </li>
                        </ul>
                    </td>
                    <td style="position:relative; text-align: left">
                        <div class="blcok"  v-show="addProject">
                                <a class="fa fa-save"  v-show="addProject"  @click='saveProject' >&nbsp;&nbsp;保存</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                <a class="fa fa-reply"  v-show="addProject" @click="eventCancelProject">&nbsp;&nbsp;取消</a>
                        </div> 
                        <div class=" edit-area" v-show="addProject">
                           
                            <ul class="form" >
                            <li>
                                <label>项目名称：</label>
                                <span><input type="text" v-model="project.name"></span>
                            </li>
                             <li>
                                <label>项目简介：</label>
                                <span>
                                    <textarea name="" id="" cols="1" rows="4"  v-model="project.desc"></textarea>
                                </span>
                            </li>
                              <li>
                                <label>适宜人群：</label>
                                <span><input type="text"  v-model="project.fitperson"></span>
                            </li>
                             <li>
                                <label>手术手段：</label>
                                <span><textarea name="" id="" cols="1" rows="4"    v-model="project.operativeState"></textarea></span>
                            </li>
                             <li>
                                <label>手术疗程：</label>
                                <span><textarea name="" id="" cols="1" rows="4"    v-model="project.operativeProcess"></textarea></span>
                            </li>
                            <li>
                                <label>治疗时长：</label>
                                <span><textarea name="" id="" cols="1" rows="4"    v-model="project.operativeTimeSpan"></textarea></span>
                            </li>
                        
                              <li>
                                <label>是否住院：</label>
                                <span>
                                    <select name="" id=""    v-model="project.isStateInHospital">
                                        <option value="Y">是</option>
                                        <option value="N">否</option>
                                    </select>
                                </span>
                            </li>
                             <li>
                                <label>术后休息：</label>
                                <span><textarea name="" id="" cols="1" rows="4"    v-model="project.restInfo"></textarea></span>
                            </li>
                             <li>
                                <label>优点：</label>
                                <span><textarea name="" id="" cols="1" rows="4"     v-model="project.advantage"></textarea></span>
                            </li>
                             <li>
                                <label>缺点：</label>
                                <span><textarea name="" id="" cols="1" rows="4"    v-model="project.defect"></textarea></span>
                            </li>
                            <li style="height:50px;">&nbsp;</li>
                        </ul>
                       
                        </div>
                    </td>
                </tr>
               
            </tbody>
        </table>
    </div>
</template>


<script>
import $ from "jquery";
import { mapGetters } from "vuex";
import VueDialog from './Common/dialog'

export default {
  data() {
    return {
      addCatType: false,
      addProject: false,
      project:{ name:"",
                desc:"",
                fitperson:"",
                operativeState:"",
                operativeProcess:"",
                operativeTimeSpan:"",
                isStateInHospital:"N",
                restInfo:"",
                advantage:"",
                defect:""}
    };
  },
 components: { VueDialog },
  computed: mapGetters({
    list: "ProjectCatList",         //项目目录
    catsType: "ProjectCatsType",    //项目目录分类
    projectList: "ProjectList",     //项目列表
    
    
    projectDetail:{}
  }),
  created() {
    let _this = this;
    //项目目录
    _this.$store.dispatch("getProjectCats").then(function(guid) {
      //项目目录分类
      _this.$store.dispatch("getProjectCatTypeList", guid).then(function(guid) {
        //项目列表
        _this.$store.dispatch("getProjectList", guid);
      });
    });
  },
  mounted() {
   
    $(".edit-area").height(
      $(".body")
        .parent()
        .height() - 220
    );
  },
  methods: {
    chooseProjectCat: function(group, item) {
      let _this = this;
      group.forEach(element => {
        element.Selected = false;
      });

      item.Selected = true;
      _this.$store.dispatch("getProjectCatTypeList", item.Guid).then(function(guid){
         //项目列表
        _this.$store.dispatch("getProjectList", guid);
      });
    },
    chooseProjectCatTypeList:function(catsTypeList, item){
      catsTypeList.forEach(element => {
        element.Selected = false;
      });

      item.Selected = true;
      this.$store.dispatch("getProjectList", item.Guid).then(function(){
        // 获取产品detail
      });
     
    },
    deleteProjectCat:function(){

    },
    deleteProjectCatType:function(){
      
    },
    deleteProject:function(){
      
    },
    saveProjectCatType:function(name){
      console.log('save project cat type')
      //this.$store.dispatch("saveProject", this.projectDetail);
    },
    saveProject:function(){
      console.log('save project ')
      console.log(JSON.stringify(this.project))
      //this.$store.dispatch("saveProjectCatType", this.projectDetail);
    },
    eventAddCatType: function() {
      this.addCatType = true;
    },
    eventCancelCatType: function() {
      this.addCatType = false;
    },
    eventAddProject: function() {
      this.addProject = true;
    },
    eventCancelProject: function() {
      this.addProject = false;
      this.project ={ name:"",desc:"",fitperson:"",operativeState:"",operativeProcess:"",operativeTimeSpan:"",isStateInHospital:"N",restInfo:"",advantage:"",defect:""}
    }
    
  }
};
</script>


<style scoped>
a.button {
  cursor: pointer;
  color: #f60;
}

td {
  vertical-align: top;
}

ul {
  margin: 0px;
  padding: 0px;
}
ul li {
  line-height: 30px;
  border-bottom: 1px #ccc solid;
  display: flex;
  cursor: pointer;
}
ul li:last-child {
  border-bottom: 0px;
}
ul li.active {
  background: #04abf3;
  color: #fff;
}
ul li span {
  text-indent: 5px;
}
ul li span.w80 {
  width: 70%;
}
ul li span.w20 {
  width: 30%;
  display: flex;
  justify-content: flex-end;
}
ul li a.opt {
  visibility: visible;
  align-self: flex-end;
  height: 70%;
  padding: 0px 5px;
}
ul li:hover a.opt {
  visibility: visible;
  align-self: flex-end;
}

ul li input {
  width: 94%;
  margin: 1px;
  margin-bottom: 4px;
  margin-top: 4px;
}
ul li button {
  width: 100%;
  border: 1px #ccc solid;
}
ul li button.half {
  width: 50%;
  float: left;
}
ul li.blcok {
  display: inline-block;
  width: 100%;
  text-align: center;
  color: #ff00e6;
}
div.blcok {
  display: inline-block;
  width: 99.5%;
  text-align: center;
  color: #ff00e6;
  position: absolute;
  bottom: 0px;
  height: 30px;
  line-height: 30px;
  border-top:1px #ccc solid;
  background: #fff;
  z-index: 9;
}

ul.form li {
  border: 0px;
  min-height: 35px;
  line-height: 35px;
  padding-bottom: 5px;
}
ul.form li input {
  height: 25px;
  line-height: 25px;
}
td .edit-area {
  overflow: scroll;
  position: relative;
}

ul.form li label {
  width: 65px;
  text-align: right;
}
ul.form li span {
  width: 90%;
}
ul.form li textarea {
  width: 94%;
  border: 1px #ccc solid;
  margin-left: 1px;
}
</style>
