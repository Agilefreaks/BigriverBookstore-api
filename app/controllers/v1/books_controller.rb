class V1::BooksController < ApplicationController
  def index
    @pagy, books = pagy(Book.all)
    render json: BookSerializer.new(books).serialized_json
  end
end