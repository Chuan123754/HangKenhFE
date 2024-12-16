//let btn = document.getElementById("btn-to-top");

//window.onscroll = function () { scrollFunction() };

//function scrollFunction() {
//    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
//        btn.style.display = "flex";
//    } else {
//        btn.style.display = "none";
//    }
//}

//const bannerSlide = new Swiper('.banner-slide', {
//    // Optional parameters
//    loop: true,
//    autoplay: true,
//    // If we need pagination
//    pagination: {
//        el: '.swiper-pagination',
//    },
//    // Navigation arrows
//    navigation: {
//        nextEl: '.swiper-button-next',
//        prevEl: '.swiper-button-prev',
//    },
//    // If we need pagination
//    slidesPerView: 5,
//    spaceBetween: 0,
//    watchSlidesProgress: true,
//    centeredSlides: true,
//});

//const trendingSlide = new Swiper('.trending-slide', {
//    loop: true,
//    slidesPerView: 1.5,
//    spaceBetween: 0,
//    watchSlidesProgress: true,
//    centeredSlides: true,
//    pagination: {
//        el: '.swiper-pagination',
//    },
//    // Navigation arrows
//    navigation: {
//        nextEl: '.swiper-button-next',
//        prevEl: '.swiper-button-prev',
//    },
//});

//const productSlide = new Swiper('.product-slide', {
//    loop: true,
//    slidesPerView: 1.5,
//    spaceBetween: 0,
//    watchSlidesProgress: true,
//    centeredSlides: true,
//    pagination: {
//        el: '.swiper-pagination',
//    },
//    // Navigation arrows
//    navigation: {
//        nextEl: '.swiper-button-next',
//        prevEl: '.swiper-button-prev',
//    },
//});

//const section5Slide = new Swiper('.section-5-slide', {
//    // Optional parameters
//    loop: true,
//    // autoplay: true,
//    // If we need pagination
//    pagination: {
//        el: '.swiper-pagination',
//    },
//});

//const bannerItems = document.getElementsByClassName('banner-item');
//if (bannerItems.length > 0) {
//    const galleryContainer = document.querySelector(".banner");
//    const galleryItems = galleryContainer.querySelectorAll(".banner-item");

//    if (galleryItems.length) {
//        const defaultIndex = 2; // Vị trí mặc định là banner-item thứ 3 (index 2)

//        const updateBannerItems = () => {
//            galleryItems.forEach((item, index) => {
//                if (item.isHovered) {
//                    document.querySelector('.banner-item.default').classList.remove('active');
//                    item.classList.add("active");
//                    item.querySelector('.banner-title').style = 'visibility: visible; animation-delay: 0.1s; animation-name: bounceInUp;';
//                    item.querySelector('.banner-description').style = 'visibility: visible; animation-delay: 0.2s; animation-name: bounceInUp;';
//                    item.querySelector('.shop-link').style = 'visibility: visible; animation-delay: 0.3s; animation-name: bounceInUp;';
//                    item.querySelector('.banner-title').classList.add('bounceInUp', 'animated');
//                    item.querySelector('.banner-description').classList.add('bounceInUp', 'animated');
//                    item.querySelector('.shop-link').classList.add('bounceInUp', 'animated');
//                    window.wow.sync();
//                } else {
//                    item.classList.remove("active");
//                    item.querySelector('.banner-title').style = '';
//                    item.querySelector('.banner-description').style = '';
//                    item.querySelector('.shop-link').style = '';
//                    item.querySelector('.banner-title').classList.remove('bounceInUp', 'animated');
//                    item.querySelector('.banner-description').classList.remove('bounceInUp', 'animated');
//                    item.querySelector('.shop-link').classList.remove('bounceInUp', 'animated');
//                }
//            });
//        };

//        // Gán sự kiện 'mouseleave' để trở về trạng thái mặc định
//        document.querySelector('.section-banner').addEventListener('mouseleave', () => {
//            galleryItems.forEach((item) => item.isHovered = false); // Xóa trạng thái hover
//            galleryItems[defaultIndex].classList.add('active'); // Đặt lại mặc định
//            galleryItems[defaultIndex].querySelector('.banner-title').style = 'visibility: visible; animation-delay: 0.1s; animation-name: bounceInUp;';
//            galleryItems[defaultIndex].querySelector('.banner-description').style = 'visibility: visible; animation-delay: 0.2s; animation-name: bounceInUp;';
//            galleryItems[defaultIndex].querySelector('.shop-link').style = 'visibility: visible; animation-delay: 0.3s; animation-name: bounceInUp;';
//            galleryItems[defaultIndex].querySelector('.banner-title').classList.add('bounceInUp', 'animated');
//            galleryItems[defaultIndex].querySelector('.banner-description').classList.add('bounceInUp', 'animated');
//            galleryItems[defaultIndex].querySelector('.shop-link').classList.add('bounceInUp', 'animated');
//        });

//        // Đặt trạng thái mặc định khi khởi động
//        galleryItems[defaultIndex].isHovered = true;
//        galleryItems[defaultIndex].classList.add('default', 'active');
//        updateBannerItems();

//        // Gán sự kiện 'mouseenter' cho từng banner-item
//        galleryItems.forEach((item) => {
//            item.addEventListener("mouseenter", () => {
//                galleryItems.forEach((otherItem) => {
//                    otherItem.isHovered = otherItem === item;
//                }); 
//                updateBannerItems();
//            });
//        });
//    }
//}

