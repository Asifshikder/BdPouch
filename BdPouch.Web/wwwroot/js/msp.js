$(document).ready(function(){
    $(".navbar-toggler").click(function(){
      $("body").toggleClass("f");
      $(".humberger__menu__overlay").toggleClass("active");
    });
  });

  $(document).ready(function(){
    $(".msp-close").click(function(){
      $("body").toggleClass("f");
      $(".msp-nave-add-classs").removeClass("show");
      $(".humberger__menu__overlay").removeClass("active");
    });
  });

  $(".humberger__menu__overlay").on('click', function () {
    $(".msp-nave-add-classs").removeClass("show");
    $(".humberger__menu__overlay").removeClass("active");
      $("body").removeClass("f");
      $(".shop-cart").removeClass("active");
  });

$(document).ready(function () {
   
    $(".navbar .show-shop").on('click', function () {
        $(".shop-cart").addClass("active");
        $("body").toggleClass("f");
        $(".humberger__menu__overlay").toggleClass("active");
    });

    $(".shop-cart .hide-shop").on('click', function () {
        $(".msp-nave-add-classs").removeClass("show");
        $(".humberger__menu__overlay").removeClass("active");
        $("body").removeClass("f");
        $(".shop-cart").removeClass("active");
    });
});