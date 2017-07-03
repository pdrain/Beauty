import axios from '../../http'
import * as types from '../types'
import * as api from '../../api'
import $ from 'jquery'

const state = {
    projectCat: {},
    projectCatList: [],
    project: {},
    projectList: []
}

const getters = {
    ProjectCat: state => state.projectCat,
    ProjectCatList: state => state.projectCatList,
    Project: state => state.projectCat,
    ProjectList: state => state.projectList
}

const actions = {
    getProjectCats({ commit, state }) {
        return new Promise(function (res, rej) {
            axios.get(api.GET_PROJECT_CAT_LIST).then(function (result) {

                let _data = result.data;
                if (_data.Code == 0) {
                    commit(types.GET_PROJECT_CAT_LIST, _data.Result)
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
    editProjectCat({ commit, state }, catId) {
        return new Promise(function (res, rej) {
            let url = api.GET_PROJECT_CAT + '/' + catId;
            axios.get(url).then(function (result) {


                let _data = result.data;
                if (_data.Code == 0) {
                    commit(types.GET_PRODUCT_CAT, _data.Result)
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
    deleteProjectCat({ commit, state }, catId) {
        return new Promise(function (res, rej) {
            axios.get(api.GET_PROJECT_CAT_LIST).then(function (res) {
                res.call();
            }, function (err) {
                console.log(err);
            });
        });
    },
    saveProjectCat({ commit, state }) {
        return new Promise(function (res, rej) {
            axios.get(api.SAVE_PROJECT_CAT).then(function (res) {
                res.call();
            }, function (err) {
                console.log(err);
            });
        });

    },
    getProject({ commit, state }, pId) {
        return new Promise(function (res, rej) {
            //TODO 调用service
            let data = {};
            if (pId === 0) {
                //新增产品
                data = { ID: 3, Name: 'sss', CatID: 0 };
                commit(types.GET_PROJECT, data);
                res.call();
            }
            if (pId === 1) {
                //编辑产品

                let selectedItem = state.projectList.filter((item) => item.Selected === true)
                if (selectedItem.length == 0) {
                    rej.call(this, '请选择需要编辑的美容项目');
                } else {
                    data = selectedItem[0];
                    commit(types.GET_PROJECT, data);
                    res.call();
                }
            }

        });
    },
    getProjectList({ commit, state }) {
        return new Promise(function (res, rej) {
            //TODO 调用service

            let data = [
                { ID: 1, Name: '111111111111111', CatID: 1 },
                { ID: 2, Name: '2222222222222', CatID: 1 },
                { ID: 3, Name: '3333333333333', CatID: 1 },
                { ID: 4, Name: '44444444444444', CatID: 1 },
            ];
            $.each(data, function (i) {
                data[i].Selected = false;
            })
            commit(types.GET_PROJECT_LIST, data);
        });
    },
    deleteProject({ commit, state }) {
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
    singleProjectSelect({ commit, state }, pId) {
        let _data = state.projectList;
        $.each(_data, (i) => {

            if (pId !== _data[i].ID) {
                _data[i].Selected = false;
            }

        });
        commit(types.GET_PROJECT_LIST, _data);
    },
    saveProject({ commit, state }) {
        let validate = function () {
            if (state.project.Name === '' || state.project.Name === undefined) {
                return { value: false, msg: '产品名称不能为空！' }
            }
            if (state.project.DisplayImg === '' || state.project.DisplayImg === undefined) {
                return { value: false, msg: '请选择产品显示图片！' }
            }
            if (state.project.ShortDesc === '' || state.project.ShortDesc === undefined) {
                return { value: false, msg: '产品简介不能为空！' }
            }
        }
        return new Promise(function (res, rej) {
            let validateResult = this.validate();
            if (!validateResult.value) {
                rej.call(this, validateResult.msg);
            } else {
                //TODO 调用service
                res.call();
            }

        });
    }

}

const mutations = {
    [types.GET_PROJECT_CAT_LIST](state, data) {
        state.projectCatList = data;

    },
    [types.GET_PROJECT_CAT](state, data) {
        state.projectCat = data;
    },
    [types.GET_PROJECT](state, data) {
        state.project = data;

    },
    [types.GET_PROJECT_LIST](state, data) {

        state.projectList = data;

    },

}

export default {

    state,
    getters,
    actions,
    mutations
}