//判断是否为空
function IsNullOrEmpty(obj) {
    var flag = false;
    if (obj == null || obj == undefined || typeof (obj) == 'undefined') {
        flag = true;
    } else if (typeof (obj) == 'string') {
        obj = jQuery.trim(obj);
        if (obj == '' || obj == 'null' || obj == 'undefined' || obj == 'NULL' || obj == 'UNDEFINED') {
            flag = true;
        }
    }
    else {
        flag = false;
    }
    return flag;
}
//获取输入的键值
function GetKeyCode(event) {
    var e;
    if (event.which != "") { e = event.which; }
    else if (event.charCode != "") { e = event.charCode; }
    else if (event.keyCode != "") { e = event.keyCode; }
    return e;
}

/////////////////////////////////////////////////////////
///以下是一些校验函数。。。。。。。。。。
/////////////////////////////////////////////////////////

//整型
function isInteger(strValue) {
    var objRegExp = /(^-?\d\d*$)/;
    return objRegExp.test(strValue);
}

//为空
function isEmpty(strValue) {
    if (strValue) { return jQuery.trim('' + strValue) == '' } else { return true };
}

//Email
function isEmail(strValue) {
    // var objRegExp = /^[a-z0-9]([a-z0-9_\-\.]*)@([a-z0-9_\-\.]*)(\.[a-z]{2,4}(\.[a-z]{2}){0,2})$/i;
    var objRegExp = new RegExp(/^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]+$/);
    return objRegExp.test(strValue);
}



//数字类型
function isNumeric(strValue) {

    var objRegExp = /(^-?\d\d*\.\d*$)|(^-?\d\d*$)|(^-?\.\d\d*$)/;
    return objRegExp.test(strValue);
}

//日期类型
function isCNDate(strValue) {
    var objRegExp = /^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$/


    if (!objRegExp.test(strValue))
        return false;
    else {
        var arrayDate = strValue.split(RegExp.$1);
        var intDay = parseInt(arrayDate[2].replace(/^0/g, ''), 10);
        var intYear = parseInt(arrayDate[0], 10);
        var intMonth = parseInt(arrayDate[1].replace(/^0/g, ''), 10);

        if (intMonth > 12 || intMonth < 1) {
            return false;
        }

        var arrayLookup = { '1': 31, '3': 31, '4': 30, '5': 31, '6': 30, '7': 31, '8': 31, '9': 30, '10': 31, '11': 30, '12': 31 };

        if (arrayLookup[intMonth] != null) {
            if (intDay <= arrayLookup[intMonth] && intDay != 0)
                return true;
        }

        if (intMonth - 2 == 0) {
            var booLeapYear = (intYear % 4 == 0 && (intYear % 100 != 0 || intYear % 400 == 0));
            if (((booLeapYear && intDay <= 29) || (!booLeapYear && intDay <= 28)) && intDay != 0)
                return true;
        }
    }
    return false;
}
//判断是否是汉字、字母、数字、下划线组成
function isChinaOrNumbOrLett(s) {
    var regu = "^[0-9a-zA-Z_\u4e00-\u9fa5]+$";
    var re = new RegExp(regu);
    if (re.test(s)) {
        return true;
    }
    else {
        return false;
    }
}


//判断是否是汉字、字母、数字、?组成
function isChinaOrNumbOrLettAnswer(s) {
    var regu = "^[0-9a-zA-Z?\u4e00-\u9fa5]+$";
    var re = new RegExp(regu);
    if (re.test(s)) {
        return true;
    }
    else {
        return false;
    }
}



//判断是否是汉字、字母、数字组成
function isChinaOrNumbOrLettNoline(s) {
    var regu = "^[0-9a-zA-Z\u4e00-\u9fa5]+$";
    var re = new RegExp(regu);
    if (re.test(s)) {
        return true;
    }
    else {
        return false;
    }
}

//判断是否是字母、数字、组成 
function isNumbOrLett(s) {
    var regu = "^[0-9a-zA-Z]+$";
    var re = new RegExp(regu);
    if (re.test(s)) {
        return true;
    }
    else {
        return false;
    }
}


//大于0
function isPositive(strValue) {
    if (isNumeric(strValue)) { if (strValue > 0) return true; else return false; }
    return false;
}

//大于等于0
function isNogeative(strValue) {
    if (isNumeric(strValue)) { if (strValue >= 0) return true; else return false; }
    return false;
}
//小于等于0
function isNegative(strValue) {
    if (isNumeric(strValue)) { if (strValue <= 0) return true; else return false; }
    return false;
}

//大于等于0，小于等于100
function isHundred(strValue) {
    return NumberRange(strValue, 0, 100);
}

function isNumInRange(strValue, fMin, fMax) {
    if (isNumeric(strValue)) { if ((strValue >= fMin) && (strValue <= fMax)) return true; else return false };
    return false;
}
//一个两个时间比较函数,传入两个控件的Id，其它地方没有改
function CompareDate(o1, o2) {

    var b = true;
    var str1 = document.all(o1).value; //开始日期,格式2003－09-09
    var str2 = document.all(o2).value; //结束日期,格式2003－09-09
    str1 = str1.replace(/-/g, "\/");
    str2 = str2.replace(/-/g, "\/");
    var time1 = new Date(str1);
    var time2 = new Date(str2);

    if (time1 > time2) {
        b = false;
    }
    return b;
}

//一个两个时间比较函数,其它地方没有改  开始日期,格式2003－09-09
function CompareDateStr(o1, o2) {
    var b = true;
    var str1 = o1.replace(/-/g, "\/");
    var str2 = o2.replace(/-/g, "\/");
    var time1 = new Date(str1);
    var time2 = new Date(str2);

    if (time1 > time2) {
        b = false;
    }
    return b;
}

//验证正则表达式
var regexs = {
    isphone: /^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/, //电话
    isnum: /^[0-9]*[1-9][0-9]*$/, //正整数
    ismoney: /^\d+(\.\d{2})?$/, //小数点后两位
    //ismobile: /^((13[0-9])|(15[0-9])|(18[0-9]))[0-9]{8}$/, //手机
    ismobile: /^(((13[0-9]{1})|(15[0-9]{1})|(17[0-9]{1})|(18[0-9]{1}))+\d{8})$/, //手机
    isemail: /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/, //邮箱
    iszip: /^[0-9]{6}$/, //邮政编码
    isurl: new RegExp("^((https|http|ftp|rtsp|mms)?://)"
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@@)?" // ftp的user  
        + "(([0-9]{1,3}.){3}[0-9]{1,3}" // ip形式的url- 199.194.52.184   
        + "|" // 允许ip和domain（域名）   
        + "([0-9a-z_!~*'()-]+.)*" // 域名- www.   
        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]." // 二级域名   
        + "[a-z]{2,6})" // first level domain- .com or .museum   
        + "(:[0-9]{1,4})?" // 端口- :80   
        + "((/?)|" // a slash isn't required if there is no file name   
        + "(/[0-9a-z_!~*'().;?:@@&=+$,%#-]+)+/?)$"), //网址
    isfax: /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/, //传真
    isidcard: /^(\d{6})(18|19|20)?(\d{2})([01]\d)([0123]\d)(\d{3})(\d|X)?$/ //身份证号

}
//验证方法
function validatetext(obj, type) {
    var texts = $.trim(obj);
    var regex = regexs[type];
    if (texts != null && texts != "") {
        if (!regex.test(texts)) {

            return false;
        }
        else {
            return true;
        }
    }
}


/*
下面是Ajax调用
*/
function ajaxSuccess(Result) { }

function ajaxError(XMLHttpRequest, textStatus, errorThrown) {
    // alert('error:' + errorThrown + '\n' + XMLHttpRequest.responseText);
}
function ajaxBefore(XMLHttpRequest) { }
function ajax(url, data, successFun, errorFun, beforeFun) {
    ajaxFun(url, data, null, successFun, errorFun, beforeFun);
}

function ajaxFun(url, data, datatype, successFun, errorFun, beforeFun) {

    if (typeof (errorFun) != 'function') {
        errorFun = ajaxError;
    }
    if (typeof (beforeFun) != 'function') {
        beforeFun = ajaxBefore;
    }
    var flag = false;
    if (IsNullOrEmpty(datatype)) {
        datatype = 'text';
    } else {
        flag = true;
    }

    jQuery.ajax({
        url: url,
        type: 'POST',
        timeout: 300000,
        data: data,
        cache: true,
        dataType: datatype,
        beforeSend: beforeFun,
        error: errorFun,
        success: function (Result) {
            if (!IsNullOrEmpty(Result) && !flag && datatype == 'text') {//说明是未指定数据类型,就默认转换为JSON
                try {
                    Result = jQuery.parseJSON(Result);
                }
                catch (e) {
                    //解决ajax请求时 登录Session失效 跳转到登陆页面
                    window.location = "/home";
                }
            }
            if (!IsNullOrEmpty(Result.LostUrl)) { window.location = Result.LostUrl; }
            if (typeof (successFun) == 'function') {
                successFun(Result);
            }
        }
    });
}

//刷新打开页面
function OpenOfRefresh() {
    if (null != window.opener) {
        try {
            var openwin = window.opener;
            openwin.location.reload();
        }
        catch (e) {
            return;
        }
    }
}
//刷新父页面--如果存在父页面的话
function ParentOfRefresh() {
    if (null != window.parent) {
        window.parent.location.assign(window.parent.location);
    }
}


//加法 
function accAdd(arg1, arg2) {
    var r1, r2, m;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    m = Math.pow(10, Math.max(r1, r2))
    return (arg1 * m + arg2 * m) / m;
}
//减法 
function Subtr(arg1, arg2) {
    var r1, r2, m, n;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    m = Math.pow(10, Math.max(r1, r2));
    n = (r1 >= r2) ? r1 : r2;
    return ((arg1 * m - arg2 * m) / m).toFixed(n);
}
//乘法
function accMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m);
}


function showvideodetail(code) {
    layer.open({
        title: false,
        shadeClose: true,
        type: 2,
        area: ['60%', '80%'],
        skin: false, //边框
        closeBtn: 1,
        content: ['/VideoView?code=' + code, 'laypage']
    });

}