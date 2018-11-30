<template>
    <div class="c-settings">
        <div class="c-setting__container">
            <h2>{{$t("settings_title")}}</h2>
            <h3>{{$t("langpref")}}</h3>
            <div class="c-langSwitcher">
                <lang-switch></lang-switch>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
@import '../style/components/components.settings';
</style>


<script>

import { i18n } from "@/plugins/i18n";
import { en, nl } from "vuejs-datepicker/dist/locale";
import LangSwitch from '../components/LanguageSwitcher';

export default {
    name: "Settings",
    components:{
        LangSwitch,
    },

    methods:{
    getLanguage: function() {
      let lang;
      i18n.locale == "en" ? (lang = en) : (lang = nl);
      return lang;
    }
    },
}
</script>

