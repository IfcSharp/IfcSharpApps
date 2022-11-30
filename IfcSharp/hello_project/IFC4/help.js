// help.js is sed for html-ifc-files created with IfcSharp (see https://github.com/IfcSharp)

function EntityHelp(layer, entity) {
    window.open(document.getElementById("SpecificationBaseUrl").getAttribute("href") + '/schema/ifc' + layer.toLowerCase() + '/lexical/ifc' + entity.toLowerCase() + '.htm');
}


function ShowHref() {
    window.open(document.getElementById("SpecificationBaseUrl").getAttribute("href"));
}

