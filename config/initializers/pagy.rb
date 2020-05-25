require 'pagy/extras/headers'

Pagy::VARS[:items] = 10
Pagy::VARS[:headers] = {page: 'Current-Page', items: 'Per-Page', pages: false, count: 'Total'}
