//用户登录
export const DO_ADMIN_LOGIN="api2/User/Login";


//获取所有业务员
export const GET_SALES="api2/project/GetSales";
//获取新申请业务员
export const GET_SALES_APPLY="api2/project/GetNewApplySales";



//美容项目目录
export const GET_PROJECT_CATS="api2/project/GetProjectCats";
//美容项目目录分类
export const GET_PROJECT_CAT="api2/Project/GetProjectCatType"
//美容项目分类列表
export const GET_PROJECT_CAT_LIST="api2/project/GetProjectCatTypeList";
//新增美容项目分类
export const ADD_PROJECT_CAT_TYPE="api2/Project/AddProjectCatType"
//新增美容项目分类
export const UPDATE_PROJECT_CAT_TYPE="api2/Project/UpdateProjectCatType"
//删除美容项目目录
export const DELETE_PROJECT_CAT="api2/Project/DeleteProjectCat"


//美容项目详情
export const GET_PROJECT="api2/Project/getprojectdetail";
//美容项目列表
export const GET_PROJECT_LIST="api2/project/GetProjectDetailList";
//新增美容项目
export const ADD_PROJECT="api2/Project/AddProjectDetail"
//更新美容项目
export const UPDATE_PROJECT="api2/Project/UpdateProjectDetail"
//删除美容项目
export const DELETE_PROJECT="api/Project/deleteProjectDetail";




//美容产品分类
export const GET_PRODUCT_CAT="api/ProductCat/{0}";
//美容从产品分类列表
export const GET_PRODUCT_CAT_LIST="api/ProductCat";
//删除美容产品分类
export const DELETE_PRODUCT_CAT="api/productcat/delete/{0}";

//美容产品
export const GET_PRODUCT="api/product/{0}";
//删除美容产品
export const DELETE_PRODUCT="api/product/delete/{0}";
//美容产品列表
export const GET_PRODUCT_LIST="api/productlist";




//--客户预约开始--------------------------------------------------------------

//获取客户预约
export const GET_SUBSCRIBERS="api2/order/getsubscribers"

//受理客户预约
export const ACCEPT_SUBSCRIBERS="api2/order/acceptsubscribers"

//拒绝客户预约
export const REFUSE_SUBSCRIBERS="api2/order/refusesubscribers"

//取消客户预约
export const CANCEL_SUBSCRIBERS="api2/order/cancelsubscribers"

//--客户预约结束--------------------------------------------------------------


//客户预约
export const GET_ORDERS="";