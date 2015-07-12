function redireccionar(pagina) 
{
    location.href=pagina
};

function actualizar() 
{
    location.reload()
};

 var addTab = function (tabPanel, id, url) {
            var tab = tabPanel.getComponent(id);

            if (!tab) {
                tab = tabPanel.add({ 
                    id       : id, 
                    title    : id, 
                    closable : true,                    
                    autoLoad : {
                        showMask : true,
                        url      : url,
                        mode     : "iframe",
                        maskMsg  : "Cargando..."
                            }        
                });

                tab.on("activate", function () {
                    var item = MenuPanel1.menu.items.get(id + "_item");
                    
                    if (item) {
                        MenuPanel1.setSelection(item);
                    }
                }, this);
            }
            else
            {
                tab.reload();
            }
            
            tabPanel.setActiveTab(tab);
        }