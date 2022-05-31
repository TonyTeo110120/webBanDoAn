<template>
    <div>
        <Header/>
        <div class="Distance">
            
        </div>
         <div class="container">
             <CarouselNew />
         </div>
         
        <Nuxt/>
       
        <Footer/>

       
    </div>
</template>

<script>
import Header from '@/components/Shared/Header.vue'
import CarouselNew from '@/components/index/CarouselNew'
import Footer from '@/components/Shared/Footer.vue'
export default {
    name: 'Default',
    components:{
        CarouselNew,
        Header,
        Footer,
        
    }
}
</script>
<style>
body{
    background-image: url(https://demo.goodlayers.com/recibo/landing/home-bg.jpg);
    overflow-x: hidden;
}
h1, h2, h3, h4, h5, h6, .h1, .h2, .h3, .h4, .h5, .h6{
    color: #f98394;
}
</style>