import axios from '../../http'
import * as types from '../types'
import * as api from '../../api'
import $ from 'jquery'
import { debug } from 'util';

const state = {
    projectCatList: [],
    projectCatsType: {},
    projectList: [],
    project: {}
}

const getters = {

    ProjectCatsType: state => state.projectCatsType,
    ProjectCatList: state => state.projectCatList,
    Project: state => state.project,
    ProjectList: state => state.projectList
}

const actions = {
    //项目目录
    getProjectCats ({ commit, state }) {
        return new Promise(function (res, rej) {
            axios.post(api.GET_PROJECT_CATS).then(function (result) {

                let _data = result.data;
                if (_data.Code == 0) {
                    let data = _data.Result;
                    $.each(data, function (i) {
                        data[i].Selected = false;
                    })
                    

                    if (data.length > 0) {
                        data[0].Selected = true;
                        commit(types.GET_PROJECT_CAT_LIST, data)
                        res.call(this, data[0].Guid);
                    }else{
                        commit(types.GET_PROJECT_CAT_LIST, [])
                    }
                }
                else {
                    alert(_data.Message);
                }


            }, function (err) {

                console.log(err);
            });
        });

    },
    //项目
    getProjectCatTypeList ({ commit, state }, guid) {
        return new Promise(function (res, rej) {
            axios.post(api.GET_PROJECT_CAT_LIST, { ParentGuid: guid }).then(function (result) {

                let _data = result.data;
                if (_data.Code == 0) {
                    let data = _data.Result;
                    $.each(data, function (i) {
                        data[i].Selected = false;
                    })
                    if (data.length > 0) {
                        data[0].Selected = true;
                        commit(types.GET_PROJECT_CATTYPE_LIST, data)
                        res.call(this, data[0].Guid);
                    }else{
                        commit(types.GET_PROJECT_CATTYPE_LIST, [])
                    }
                }
                else {
                    alert(_data.Message);
                }


            }, function (err) {

                console.log(err);
            });
        });

    },
    
    saveProjectCatType ({ commit, state }, param) {
        return new Promise(function (res, rej) {
            axios.post(api.ADD_PROJECT_CAT_TYPE,param).then(function (result) {
                let _data = result.data;
                if (_data.Code == 0) {
                    res.call();
                }
                else {
                    alert(_data.Message);
                }

            }, function (err) {
                console.log(err);
            });
        });

    },
    deleteProjectCatType ({ commit, state }, catId) {
        return new Promise(function (res, rej) {
            axios.get(api.GET_PROJECT_CAT_LIST).then(function (res) {
                let _data = result.data;

                if (_data.Code == 0) {
                    commit(types.DELETE_PROJECT, _data.Result);
                    res.call();
                }
                else {
                    alert(_data.Message);
                }

            }, function (err) {
                console.log(err);
            });
        });
    },
      //项目列表
      getProjectDetail ({ commit, state }, id) {
        return new Promise(function (res, rej) {

            axios.post(api.GET_PROJECT, { Id: id }).then(function (result) {
                let _data = result.data;
                if (_data.Code == 0) {
                    res.call(this,_data.Result);
                }
                else {
                    alert(_data.Message);
                }

            }, function (err) {
                console.log(err);
            });


        });
    },  
    //项目列表
    getProjectList ({ commit, state }, guid) {
        return new Promise(function (res, rej) {

            axios.post(api.GET_PROJECT_LIST, { CatGuid: guid }).then(function (result) {
                let _data = result.data;
                if (_data.Code == 0) {
                    let data = _data.Result||[];
                    $.each(data, function (i) {
                        data[i].Selected = false;
                    })
                    commit(types.GET_PROJECT_LIST, data);
                    res.call();
                }
                else {
                    alert(_data.Message);
                }

            }, function (err) {
                console.log(err);
            });


        });
    },   
    deleteProject ({ commit, state }) {
        return new Promise(function (res, rej) {

            let selectedItem = state.projectList.filter((item) => item.Selected === true)
            if (selectedItem.length == 0) {
                rej.call(this, '请选择需要删除的美容项目');
            } else {
                //TODO 调用service
                res.call();
            }

        });
    },
    saveProject ({ commit, state },projectDetail) {
        
        return new Promise(function (res, rej) {
            
               //TODO 调用service
               axios.post(api.ADD_PROJECT, projectDetail).then(function (result) {
                let _data = result.data;
                if (_data.Code == 0) {
                    
                    //commit(types.ADD_PROJECT, data);
                    res.call();
                }
                else {
                    alert(_data.Message);
                }

            }, function (err) {
                console.log(err);
            }); 
                
            
        })
    }
}

const mutations = {
    [types.GET_PROJECT_CAT_LIST] (state, data) {
        state.projectCatList = data;

    },
    [types.GET_PROJECT_CATTYPE_LIST] (state, data) {
        state.projectCatsType = data;

    },

    [types.GET_PROJECT] (state, data) {
        state.project = data;

    },
    [types.GET_PROJECT_LIST] (state, data) {

        state.projectList = data;

    },
    [types.ADD_PROJECT](state, data) {
    },

}

export default {

    state,
    getters,
    actions,
    mutations
}