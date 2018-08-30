﻿$(function () {
    GetTableList();
})

function btnsearch() {
    $("#tabledate").bootstrapTable('refresh');
}

function btnreset() {
    $("#search_group input[type='text']").each(function () {
        $(this).val("");
    });
}


function fillbootstarptable(url, nowcolumns, nowparams) {
    $("#tabledate").bootstrapTable({
        url: url,
        method: 'post',
        contentType: "application/x-www-form-urlencoded",
        cache: false,
        queryParams: function (params) {
            var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
                limit: params.limit,   //页面大小
                offset: params.offset  //页码
            };
            if (nowparams != null) {
                $(nowparams).each(function (index) {
                    var dom = $("#" + this + "");
                    temp["" + dom.attr("para") + ""] = dom.val();
                });
            }
            return temp;
        },           //传递参数（*）
        clickToSelect: true,                //是否启用点击选中行
        uniqueId: "EID",                     //每一行的唯一标识，一般为主键列
        rowStyle: function (row, index) {
            //这里有5个取值代表5中颜色['active', 'success', 'info', 'warning', 'danger'];
            var strclass = "";
            if (row.EPId == "0") {
                strclass = 'success';
            }
            else {
                return {};
            }
            return { classes: strclass }
        },
        columns: nowcolumns
    })
}

function fillbootstarptablepage(url, nowcolumns, nowparams, nowpagesize) {
    $('#tabledate').bootstrapTable({
        url: url,         //请求后台的URL（*）
        method: 'post',
        contentType: "application/x-www-form-urlencoded",
        toolbar: '#toolbar',                //工具按钮用哪个容器
        striped: true,                      //是否显示行间隔色
        cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        pagination: true,                   //是否显示分页（*）
        sortable: true,                     //是否启用排序
        //sortOrder: "desc",                   //排序方式
       
        queryParams: function (params) {
            var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
                limit: params.limit,   //页面大小
                offset: params.offset  //页码
            };
            if (nowparams != null) {
                $(nowparams).each(function (index) {
                    var dom = $("#" + this + "");
                    temp["" + dom.attr("para") + ""] = dom.val();
                });
            }
            
            return temp;
        },           //传递参数（*）
        sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1,                       //初始化加载第一页，默认第一页
        pageSize: nowpagesize,                       //每页的记录行数（*）
        pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
        search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
       
        showColumns: true,                  //是否显示所有的列
        showRefresh: true,                  //是否显示刷新按钮
        minimumCountColumns: 1,             //最少允许的列数
        clickToSelect: true,                //是否启用点击选中行
        //height: 480,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
        uniqueId: "EID",                     //每一行的唯一标识，一般为主键列
        showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
        cardView: false,                    //是否显示详细视图
        //detailView: false,                   //是否显示父子表
        columns: nowcolumns
    });
}



