class V1::BooksController < ApplicationController
  has_scope :by_genre_ids
  has_scope :by_title

  def index
    @pagy, books = pagy(apply_scopes(Book.all))
    render json: BookSerializer.new(books).serialized_json
  end
end