
/* 表格 行变色*/


function hover() {
    var $bg;
    $('#thetable table tr:not(:has("th"))').hover(

      function () {        
          $bg = $(this).css('background-color');
          $(this).css('background-color', 'lightblue');
      },

      function () {
          $(this).css('background-color', $bg);
      }
     );
}


function isselect() {

    var checked = 0;
    var allvalue = '';

    var _c = 0;
    $(".ck_item").each(

     function () {
        if($(this).is(':checked')) {
            checked++;
        

            if (checked > 1) {
                allvalue += ',' + $(this).val();
            }
            else {
                allvalue = $(this).val();
            }
           }
         
     } );

    $("#hf_ids").val(allvalue);

    if (checked > 0)
    {
     return true;
    }
    else
    {
        alert("请至少选择一条记录");
        return false;
    }

}



function selectall(obj) {
    var checkFlag = $(obj).is(':checked');
     
        $(".ck_item").each(
        function()
        {
          $(this).prop("checked", checkFlag);
        }
        );

      
}

 






/* PopMenu */

var modclickcount = 0;
function modclick(obj,tableid) {
    var modcount = $('#modcount');
    var modlayer = $('#modlayer');
    if (obj.checked == true) {
        modclickcount++;
    }
    else {
        modclickcount--;
    }
    modcount.html(modclickcount);

   if (modclickcount > 0) {
       var top_offset = obj.offsetTop;

       while ((obj = obj.offsetParent).id != tableid) {
           top_offset += obj.offsetTop;
       }
   
       modlayer.css("top", top_offset+20);
        modlayer.show();
    }
    else {
        modlayer.hide();
    }



    if (modclickcount > 1) {
        $(".export").hide();
    }
    else {
        $(".export").show();
    }
     
}





function checkall(obj) {
    var num = 0;
    var chks = $("#thetable input[name='listitem']");

    if ($(obj).is(':checked')) {
        chks.attr("checked", true);
        num = chks.length;
    }
    else {
        chks.attr("checked", false);
        num = 0;
    }

    modclickcount = num;
    
     $('#modcount').html(num);
     if(num<=0)
     {
        $('#modlayer').hide();
     }
     else
     {
      $('#modlayer').show();
     }



  if (num > 1) {
      $(".export").hide();
  }
  else {
      $(".export").show();
  }

  }







  function op(action, url, popTitle, returnUrl, showIFrame) {
    

    var checked = 0;
    var allvalue = '';
    var chks = $("#thetable input[name='listitem']");

    chks.each(
     function () {
         if ($(this).is(":checked")) {
             checked++;
             if (checked > 1) {
                 allvalue += ',' + $(this).val();
             }
             else {
                 allvalue = $(this).val();
             }
         }
     }
    );



    
    
    $("#hf_ids").val(allvalue);



   
    if (!checked) {
            alert('请选择需要操作的记录');
       }
    else {

        if (action == "get") {
            return;
        }

        if (action == "delete") {
            return;
        }

       

      if(showIFrame)
        {
          ShowIframeNoScroll(url+"&ids=" + allvalue + "&returnUrl="+returnUrl, "500", "350", popTitle);
        }
        else
        {
           location.href = url+"&ids=" + allvalue;
         }
      }
          
}
  


