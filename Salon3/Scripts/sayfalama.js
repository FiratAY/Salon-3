         /* Aksiyon */


       
  //toplam li yi bulalım
  
  var toplamLi = $("ul#liste li").size();
  
  // sayfa veri sayısını belirleyelim
  
  var sayfaLi = 3 ;
  
  //sayfalamayı uygula
  
  $("ul#liste li:gt("+(sayfaLi-1)+")").hide();
  
  // sayfa sayısını bulalım                          /*Math.round ile sayıyı yuvarladık*/
  
  var sayfaSayisi = Math.ceil(toplamLi/sayfaLi);                  
  
  
  // sayfa linklerini ekleyelim
  
  for (var i = 1 ; i <= sayfaSayisi ; i++){
    $("#sayfalama").append('<a href="javascript:void(0)">'+i+'</a>');
    
    }
    
  
  // ilk sayfa aktif class ını ekleyelim
  
  $("#sayfalama a:first").addClass("aktif");
  
  // Tıklananın aktif olması
  
  $("#sayfalama a").live("click" , function(){
    var indis = $(this).index()+1;
    var gt = sayfaLi * indis ;
    $("#sayfalama a").removeClass("aktif");
    $(this).addClass("aktif");
    $("ul#liste li").hide();
    for(var i = gt-sayfaLi ; i<gt ; i++){
      $("ul#liste li:eq("+i+")").show();
      }
    
    
    });
    
    