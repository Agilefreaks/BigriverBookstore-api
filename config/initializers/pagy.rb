# frozen_string_literal: true

require 'pagy/extras/headers'
require 'pagy/extras/overflow'

Pagy::VARS[:items] = 10
Pagy::VARS[:headers] = { page: 'Current-Page', items: 'Per-Page', pages: false, count: 'Total' }
Pagy::VARS[:overflow] = :last_page
