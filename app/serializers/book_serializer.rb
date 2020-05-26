class BookSerializer
  include FastJsonapi::ObjectSerializer
  attributes :title, :author, :isbn, :release_year, :image_url, :description
end
