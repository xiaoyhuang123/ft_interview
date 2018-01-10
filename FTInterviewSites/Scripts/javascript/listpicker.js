function addItem(listID) {
    // Get the list boxes
    var srcList = document.getElementById(listID + '_SrcList');
    var dstList = document.getElementById(listID + '_DstList');
    var selectedStateField = document.getElementById(listID + '_SelectedState');
    var allStateField = document.getElementById(listID + '_AllState');

    // return when no option selected
    if (srcList.selectedIndex == -1)
        return;

    // Move the option
    var srcOption = srcList.options(srcList.options.selectedIndex)
    var dstOption = document.createElement("OPTION");
    dstList.options.add(dstOption);
    dstOption.innerText = srcOption.text;
    dstOption.value = srcOption.value;
    srcList.remove(srcList.options.selectedIndex);


    // Record in SelectedState hidden field
    if (selectedStateField.value == '')
      selectedStateField.value = dstOption.value; 
    else
      selectedStateField.value = selectedStateField.value + ',' + dstOption.value;

    // Remove from AllState hidden field
    searchAndRemove(allStateField, dstOption.value);
}


function removeItem(listID) {
    // Get the list boxes
    var srcList = document.getElementById(listID + '_DstList');
    var dstList = document.getElementById(listID + '_SrcList');
    var selectedStateField = document.getElementById(listID + '_SelectedState');
    var allStateField = document.getElementById(listID + '_AllState');

    // return when no option selected
    if (srcList.selectedIndex == -1)
        return;

    // Move the option
    var srcOption = srcList.options(srcList.options.selectedIndex)
    var dstOption = document.createElement("OPTION");
    dstList.options.add(dstOption);
    dstOption.innerText = srcOption.text;
    dstOption.value = srcOption.value;
    srcList.remove(srcList.options.selectedIndex);

    // Record in AllState hidden field
    if (allStateField.value == '')
      allStateField.value = dstOption.value; 
    else
      allStateField.value = allStateField.value + ',' + dstOption.value;


    // Remove from SelectedState hidden field
    searchAndRemove(selectedStateField, dstOption.value);    
}


function searchAndRemove(stateField, item) {
    var newStateValue = '';
    var counter = 0;

    fields = stateField.value.split(',');
    for (i=0; i< fields.length; i++) {
        if (fields[i] != item) {
            counter ++;
            if (counter>1)
                newStateValue = newStateValue + ',' + fields[i];
            else
                newStateValue = fields[i];
        }
   }

    stateField.value = newStateValue;
}


