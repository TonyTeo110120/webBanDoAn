<template>
    <div class="text-danger card mb-4 shadow-sm">
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Họ tên: {{contact.hoTen}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Số điện thoại: {{contact.soDienThoai}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Địa chỉ Email: {{contact.diaChiEmail}}
                 </p>
            </div>
            <div class="card-header">
                 <p class="my-0 font-weight-normal">
                     Nội dung liên hệ: {{contact.noiDung}}
                 </p>
            </div>
            <div ></div>
            <div class="card">
                     Trả lời liên hệ
                     <div class="h3 card-header">
                 <textarea></textarea>
                    </div> 
            </div>
            <button class = "bg-info btn btn-primary"
            @click.prevent="OnDelete(contact.contactId)"
            >Xử lý</button>
        </div>
</template>

<script>
import catalogApi from '@/api/catalogApi'
export default {
    props:{
        contact:{
            type: Object,
            required: true,
            default(){
                return {}
            },
        },
    },
    async created(){
        await this.OnDelete()
    },
    methods:{
         async OnDelete(id){
            try {
                await catalogApi.deleteContact(this.$axios, id)
                alert("Xử lý thành công")
                this.$router.go()
            } catch (err) {
                
            }
            
        }
    }
}
</script>